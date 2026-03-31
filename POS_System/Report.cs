using System.Text;
using MySql.Data.MySqlClient;

namespace POS_system.Forms
{
    public partial class Report : Form
    {
        private bool showingSalesReport = false;

        public Report()
        {
            InitializeComponent();
            InitializeColumns();
        }

        private void InitializeColumns()
        {
            // Sales Report columns
            dgvSalesReport.Columns.Add("SaleID", "Sale ID");
            dgvSalesReport.Columns.Add("SaleDate", "Sale Date");
            dgvSalesReport.Columns.Add("TotalAmount", "Total Amount");
            dgvSalesReport.Columns.Add("CashierName", "Cashier Name");

            // Set column widths
            dgvSalesReport.Columns["SaleID"].Width = 100;
            dgvSalesReport.Columns["SaleDate"].Width = 200;
            dgvSalesReport.Columns["TotalAmount"].Width = 150;
            dgvSalesReport.Columns["CashierName"].Width = 200;

            // Apply styling
            dgvSalesReport.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            dgvSalesReport.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvSalesReport.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            dgvSalesReport.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            // Inventory Report columns
            dgvInventoryReport.Columns.Add("ProductID", "Product ID");
            dgvInventoryReport.Columns.Add("ProductName", "Product Name");
            dgvInventoryReport.Columns.Add("Price", "Price");
            dgvInventoryReport.Columns.Add("Stock", "Current Stock");

            // Set column widths
            dgvInventoryReport.Columns["ProductID"].Width = 100;
            dgvInventoryReport.Columns["ProductName"].Width = 300;
            dgvInventoryReport.Columns["Price"].Width = 150;
            dgvInventoryReport.Columns["Stock"].Width = 150;

            // Apply styling
            dgvInventoryReport.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            dgvInventoryReport.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvInventoryReport.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            dgvInventoryReport.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        }

        private void BtnSalesReport_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
            dgvSalesReport.Visible = true;
            dgvInventoryReport.Visible = false;
            btnExport.Visible = true;
            lblTotalSales.Visible = true;
            showingSalesReport = true;
        }

        private void BtnInventoryReport_Click(object sender, EventArgs e)
        {
            LoadInventoryReport();
            dgvInventoryReport.Visible = true;
            dgvSalesReport.Visible = false;
            btnExport.Visible = true;
            lblTotalSales.Visible = false;
            showingSalesReport = false;
        }

        private void LoadSalesReport()
        {
            dgvSalesReport.Rows.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(POS_system.Database.ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT s.Id, s.CreatedAt, s.TotalAmount, u.Username 
                                     FROM Sales s 
                                     LEFT JOIN Users u ON s.CashierId = u.Id 
                                     ORDER BY s.CreatedAt DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            decimal totalSales = 0;
                            int rowCount = 0;
                            while (reader.Read())
                            {
                                int saleID = reader.GetInt32("Id");
                                DateTime saleDate = reader.IsDBNull(reader.GetOrdinal("CreatedAt")) ? DateTime.Now : reader.GetDateTime("CreatedAt");
                                decimal totalAmount = reader.GetDecimal("TotalAmount");
                                string cashierName = reader.IsDBNull(reader.GetOrdinal("Username")) ? "Unknown" : reader.GetString("Username");

                                dgvSalesReport.Rows.Add(saleID, saleDate.ToString("dd/MM/yyyy HH:mm:ss"), totalAmount.ToString("C"), cashierName);

                                // Apply alternating row styling
                                if (rowCount % 2 == 0)
                                {
                                    dgvSalesReport.Rows[rowCount].DefaultCellStyle.BackColor = Color.White;
                                }
                                else
                                {
                                    dgvSalesReport.Rows[rowCount].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
                                }

                                // Format currency column
                                dgvSalesReport.Rows[rowCount].Cells["TotalAmount"].Style.ForeColor = Color.Green;
                                dgvSalesReport.Rows[rowCount].Cells["TotalAmount"].Style.Font = new Font("Arial", 10, FontStyle.Bold);

                                totalSales += totalAmount;
                                rowCount++;
                            }
                            lblTotalSales.Text = $"Total Sales: {totalSales:C}";
                            lblTotalSales.ForeColor = Color.Gold;
                            lblTotalSales.Font = new Font("Arial", 12, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales report: " + ex.Message);
            }
        }

        private void LoadInventoryReport()
        {
            dgvInventoryReport.Rows.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(POS_system.Database.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT id, name, price, stock FROM products ORDER BY name ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int rowCount = 0;
                            while (reader.Read())
                            {
                                int productID = reader.GetInt32("id");
                                string productName = reader.GetString("name");
                                decimal price = reader.GetDecimal("price");
                                int stock = reader.GetInt32("stock");

                                dgvInventoryReport.Rows.Add(productID, productName, price.ToString("C"), stock);

                                // Apply alternating row styling
                                if (rowCount % 2 == 0)
                                {
                                    dgvInventoryReport.Rows[rowCount].DefaultCellStyle.BackColor = Color.White;
                                }
                                else
                                {
                                    dgvInventoryReport.Rows[rowCount].DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
                                }

                                // Highlight low stock items
                                if (stock < 5)
                                {
                                    dgvInventoryReport.Rows[rowCount].Cells["Stock"].Style.ForeColor = Color.Red;
                                    dgvInventoryReport.Rows[rowCount].Cells["Stock"].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                                }
                                else if (stock < 10)
                                {
                                    dgvInventoryReport.Rows[rowCount].Cells["Stock"].Style.ForeColor = Color.Orange;
                                    dgvInventoryReport.Rows[rowCount].Cells["Stock"].Style.Font = new Font("Arial", 10, FontStyle.Bold);
                                }
                                else
                                {
                                    dgvInventoryReport.Rows[rowCount].Cells["Stock"].Style.ForeColor = Color.Green;
                                }

                                // Format price column
                                dgvInventoryReport.Rows[rowCount].Cells["Price"].Style.ForeColor = Color.Blue;

                                rowCount++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory report: " + ex.Message);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.FileName = showingSalesReport ? "SalesReport.csv" : "InventoryReport.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataGridView gridToExport = showingSalesReport ? dgvSalesReport : dgvInventoryReport;
                    StringBuilder sb = new StringBuilder();

                    // Add headers
                    for (int i = 0; i < gridToExport.Columns.Count; i++)
                    {
                        sb.Append(gridToExport.Columns[i].HeaderText);
                        if (i < gridToExport.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();

                    // Add rows
                    foreach (DataGridViewRow row in gridToExport.Rows)
                    {
                        for (int i = 0; i < gridToExport.Columns.Count; i++)
                        {
                            sb.Append(row.Cells[i].Value);
                            if (i < gridToExport.Columns.Count - 1)
                                sb.Append(",");
                        }
                        sb.AppendLine();
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                    MessageBox.Show("Report exported successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting report: " + ex.Message);
                }
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
