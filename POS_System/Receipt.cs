using System;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace POS_system.Forms
{
    public partial class Receipt : Form
    {
        private string[] saleItems;
        private decimal totalPrice = 0;
        private int receiptNumber = 0;
        private string cashierName = "Unknown";
        private DateTime transactionDateTime = DateTime.Now;

        public Receipt()
        {
            saleItems = new string[] { };
            InitializeComponent();
            // ensure UI is prepared when shown
            this.Shown += (s, e) => DisplayReceipt();
        }

        public Receipt(string[] items, decimal total, int receiptNo)
        {
            saleItems = items;
            totalPrice = total;
            receiptNumber = receiptNo;
            InitializeComponent();
            this.Shown += (s, e) => DisplayReceipt();
        }

        public Receipt(string[] items, decimal total, int receiptNo, string cashier)
        {
            saleItems = items;
            totalPrice = total;
            receiptNumber = receiptNo;
            cashierName = cashier;
            transactionDateTime = DateTime.Now;
            InitializeComponent();
            this.Shown += (s, e) => DisplayReceipt();
        }

        /// <summary>
        /// Populate the on-form receipt controls (DataGridView + labels) to make the receipt readable and eye-appealing.
        /// </summary>
        private void DisplayReceipt()
        {
            // Header fields
            lblReceiptNumber.Text = $"Receipt #: {receiptNumber}";
            lblDateTime.Text = transactionDateTime.ToString("dd/MM/yyyy  HH:mm:ss");
            lblTotal.Font = new Font(lblTotal.Font.FontFamily, 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.DarkGreen;

            // Prepare DataGridView columns (add if not present)
            if (dgvReceiptItems.Columns.Count == 0)
            {
                dgvReceiptItems.Columns.Clear();
                var colDesc = new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Description", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
                var colQty = new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "Qty", Width = 60, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } };
                var colPrice = new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price", Width = 100, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } };
                var colSubtotal = new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", Width = 120, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } };

                dgvReceiptItems.Columns.AddRange(new DataGridViewColumn[] { colDesc, colQty, colPrice, colSubtotal });

                // Visual styles
                dgvReceiptItems.EnableHeadersVisualStyles = false;
                dgvReceiptItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                dgvReceiptItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvReceiptItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvReceiptItems.RowTemplate.Height = 28;
                dgvReceiptItems.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                dgvReceiptItems.DefaultCellStyle.BackColor = Color.White;
                dgvReceiptItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 250);
                dgvReceiptItems.GridColor = Color.LightGray;
                dgvReceiptItems.BorderStyle = BorderStyle.None;
            }

            dgvReceiptItems.Rows.Clear();

            // Fill rows
            foreach (var item in saleItems)
            {
                // Expecting input like: "ProductName - Qty: X - Unit Price: Y - Subtotal: Z"
                string productName = item;
                string qty = "";
                string price = "";
                string subtotal = "";

                try
                {
                    string[] parts = item.Split(new[] { " - " }, StringSplitOptions.None);
                    if (parts.Length >= 4)
                    {
                        productName = parts[0];
                        qty = parts[1].Replace("Qty: ", "").Trim();
                        price = parts[2].Replace("Unit Price: ", "").Trim();
                        subtotal = parts[3].Replace("Subtotal: ", "").Trim();
                    }
                }
                catch
                {
                    // fallback: put full item into description
                    productName = item;
                }

                int rowIndex = dgvReceiptItems.Rows.Add(productName, qty, price, subtotal);

                // subtle row styling
                dgvReceiptItems.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                dgvReceiptItems.Rows[rowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
            }

            // Display total in label, right aligned visually by margin
            lblTotal.Text = $"Total: {totalPrice:C}";

            // Optional: show cashier name in the title or small label if present
            if (!string.IsNullOrWhiteSpace(cashierName))
            {
                lblDateTime.Text += $"   |   Cashier: {cashierName}";
            }
        }

        private void BtnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDoc_PrintPage;
                printDoc.DefaultPageSettings.Margins = new Margins(30, 30, 30, 30);

                using (PrintDialog printDialog = new PrintDialog 
                { 
                    Document = printDoc,
                    AllowSelection = false,
                    AllowSomePages = false
                })
                {
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        printDoc.Print();
                        MessageBox.Show("Receipt printed successfully!", "Print Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Professional receipt layout
            float y = 20;
            float left = 30;
            float right = e.PageBounds.Width - 30;

            var titleFont = new Font("Courier New", 14F, FontStyle.Bold);
            var headerFont = new Font("Courier New", 11F, FontStyle.Bold);
            var contentFont = new Font("Courier New", 9F);
            var totalFont = new Font("Courier New", 12F, FontStyle.Bold);

            // Title
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            e.Graphics.DrawString("========== POS SYSTEM RECEIPT ==========", titleFont, Brushes.Black, (left + right) / 2, y, centerFormat);
            y += 35;

            // Store Information
            e.Graphics.DrawString("Supermarket POS System", contentFont, Brushes.Black, left, y);
            y += 18;
            e.Graphics.DrawString("Receipt # " + receiptNumber, headerFont, Brushes.Black, left, y);
            y += 20;

            // Date and Time
            e.Graphics.DrawString("Date: " + transactionDateTime.ToString("dd/MM/yyyy"), contentFont, Brushes.Black, left, y);
            y += 15;
            e.Graphics.DrawString("Time: " + transactionDateTime.ToString("HH:mm:ss"), contentFont, Brushes.Black, left, y);
            y += 15;
            e.Graphics.DrawString("Cashier: " + cashierName, contentFont, Brushes.Black, left, y);
            y += 20;

            // Separator
            e.Graphics.DrawString(new string('-', 50), contentFont, Brushes.Black, left, y);
            y += 15;

            // Column Headers
            e.Graphics.DrawString("Item", contentFont, Brushes.Black, left, y);
            e.Graphics.DrawString("Qty", contentFont, Brushes.Black, left + 240, y);
            e.Graphics.DrawString("Price", contentFont, Brushes.Black, left + 300, y);
            e.Graphics.DrawString("Total", contentFont, Brushes.Black, left + 370, y);
            y += 15;

            // Separator
            e.Graphics.DrawString(new string('-', 50), contentFont, Brushes.Black, left, y);
            y += 12;

            // Items
            foreach (DataGridViewRow row in dgvReceiptItems.Rows)
            {
                if (row.IsNewRow) continue;

                string desc = row.Cells["Description"].Value?.ToString() ?? "";
                string q = row.Cells["Qty"].Value?.ToString() ?? "0";
                string p = row.Cells["Price"].Value?.ToString() ?? "0.00";
                string s = row.Cells["Subtotal"].Value?.ToString() ?? "0.00";

                // Truncate long descriptions
                if (desc.Length > 25)
                    desc = desc.Substring(0, 22) + "...";

                e.Graphics.DrawString(desc, contentFont, Brushes.Black, left, y);
                e.Graphics.DrawString(q.PadLeft(4), contentFont, Brushes.Black, left + 240, y);
                e.Graphics.DrawString(p.PadLeft(8), contentFont, Brushes.Black, left + 300, y);
                e.Graphics.DrawString(s.PadLeft(8), contentFont, Brushes.Black, left + 370, y);

                y += 15;
            }

            // Separator
            y += 5;
            e.Graphics.DrawString(new string('-', 50), contentFont, Brushes.Black, left, y);
            y += 15;

            // Total
            e.Graphics.DrawString("TOTAL AMOUNT: " + totalPrice.ToString("KES #,##0.00"), totalFont, Brushes.Black, left, y);
            y += 25;

            // Footer
            e.Graphics.DrawString(new string('=', 50), contentFont, Brushes.Black, left, y);
            y += 15;
            e.Graphics.DrawString("Thank You for Your Purchase!", headerFont, Brushes.Black, left + 40, y);
            y += 18;
            e.Graphics.DrawString("Please Visit Again", contentFont, Brushes.Black, left + 100, y);
            y += 18;
            e.Graphics.DrawString(new string('=', 50), contentFont, Brushes.Black, left, y);

            e.HasMorePages = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSaveReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    FileName = $"Receipt_{receiptNumber}_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
                    DefaultExt = ".txt",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                    {
                        // Header
                        writer.WriteLine("========== POS SYSTEM RECEIPT ==========");
                        writer.WriteLine("Supermarket POS System");
                        writer.WriteLine();
                        writer.WriteLine("Receipt # " + receiptNumber);
                        writer.WriteLine("Date: " + transactionDateTime.ToString("dd/MM/yyyy HH:mm:ss"));
                        writer.WriteLine("Cashier: " + cashierName);
                        writer.WriteLine();
                        writer.WriteLine(new string('-', 50));
                        writer.WriteLine();

                        // Column Headers
                        writer.WriteLine(string.Format("{0,-25} {1,5} {2,10} {3,10}", "Item", "Qty", "Price", "Total"));
                        writer.WriteLine(new string('-', 50));

                        // Items
                        foreach (DataGridViewRow row in dgvReceiptItems.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string desc = row.Cells["Description"].Value?.ToString() ?? "";
                            if (desc.Length > 25) desc = desc.Substring(0, 22) + "...";

                            string q = row.Cells["Qty"].Value?.ToString() ?? "0";
                            string p = row.Cells["Price"].Value?.ToString() ?? "0.00";
                            string s = row.Cells["Subtotal"].Value?.ToString() ?? "0.00";

                            writer.WriteLine(string.Format("{0,-25} {1,5} {2,10} {3,10}", desc, q, p, s));
                        }

                        writer.WriteLine();
                        writer.WriteLine(new string('-', 50));
                        writer.WriteLine();
                        writer.WriteLine("TOTAL AMOUNT: " + totalPrice.ToString("KES #,##0.00"));
                        writer.WriteLine();
                        writer.WriteLine(new string('=', 50));
                        writer.WriteLine("Thank You for Your Purchase!");
                        writer.WriteLine("Please Visit Again");
                        writer.WriteLine(new string('=', 50));
                    }

                    MessageBox.Show($"Receipt saved successfully to:\n{saveDialog.FileName}", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving receipt: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}