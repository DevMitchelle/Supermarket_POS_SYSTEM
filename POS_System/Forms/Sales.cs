using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POS_system.Forms
{
    public partial class Sales : Form
    {
        private string username;
        private DataTable cartItems = new DataTable();
        private decimal totalAmount = 0;
        private int lastSaleId = -1;

        public Sales(string user)
        {
            username = user;
            InitializeComponent();
            SetupCart();
            LoadProducts();
            AttachEventHandlers();
        }

        private void AttachEventHandlers()
        {
            Button btnAddToCart = this.Controls.Find("btnAddToCart", true).Length > 0 ? this.Controls.Find("btnAddToCart", true)[0] as Button : null;
            Button btnCompleteSale = this.Controls.Find("btnCompleteSale", true).Length > 0 ? this.Controls.Find("btnCompleteSale", true)[0] as Button : null;
            Button btnClear = this.Controls.Find("btnClear", true).Length > 0 ? this.Controls.Find("btnClear", true)[0] as Button : null;
            Button btnClose = this.Controls.Find("btnClose", true).Length > 0 ? this.Controls.Find("btnClose", true)[0] as Button : null;

            if (btnAddToCart != null)
                btnAddToCart.Click += (s, e) => AddToCart(cmbProducts, nudQuantity, dgvCart);
            if (btnCompleteSale != null)
                btnCompleteSale.Click += (s, e) => CompleteSale(dgvCart, cmbPayment, txtNotes, username);
            if (btnClear != null)
                btnClear.Click += (s, e) => ClearCart(dgvCart);
            if (btnClose != null)
                btnClose.Click += (s, e) => this.Close();

            cmbProducts.SelectedIndexChanged += (s, e) => UpdateProductInfo(cmbProducts);

            dgvCart.CellClick += (s, e) =>
            {
                if (e.ColumnIndex == 4 && e.RowIndex >= 0)
                {
                    cartItems.Rows.RemoveAt(e.RowIndex);
                    RefreshCart(dgvCart);
                }
            };
        }

        private void SetupCart()
        {
            cartItems.Columns.Add("ProductId", typeof(int));
            cartItems.Columns.Add("ProductName", typeof(string));
            cartItems.Columns.Add("Quantity", typeof(int));
            cartItems.Columns.Add("UnitPrice", typeof(decimal));
            cartItems.Columns.Add("Total", typeof(decimal));
        }

        private void LoadProducts()
        {
            try
            {
                DataTable products = Database.GetProducts();

                if (products != null && products.Rows.Count > 0)
                {
                    // Create a list to bind to ComboBox
                    var productList = new System.Collections.Generic.List<ProductItem>();

                    foreach (DataRow row in products.Rows)
                    {
                        int id = Convert.ToInt32(row["Id"]);
                        string name = row["Name"].ToString();
                        decimal price = Convert.ToDecimal(row["Price"]);
                        int stock = Convert.ToInt32(row["Stock"]);

                        productList.Add(new ProductItem 
                        { 
                            Id = id, 
                            Name = name,
                            Price = price,
                            Stock = stock,
                            Display = $"{name} - KES {price:F2} (Stock: {stock})"
                        });
                    }

                    cmbProducts.DataSource = productList;
                    cmbProducts.DisplayMember = "Display";
                    cmbProducts.ValueMember = "Id";
                    cmbProducts.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No products found in database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProductInfo(ComboBox cmbProducts)
        {
            if (cmbProducts.SelectedValue is int productId)
            {
                var product = Database.GetProductByNameOrCode(productId.ToString());
                if (product != null)
                {
                    nudQuantity.Maximum = Math.Max(1, product.Stock);
                    nudQuantity.Value = 1;

                    Label lblStockInfo = this.Controls.Find("lblStockInfo", true).Length > 0 ? 
                        this.Controls.Find("lblStockInfo", true)[0] as Label : null;
                    if (lblStockInfo != null)
                    {
                        lblStockInfo.Text = $"Stock Available: {product.Stock} units";
                        lblStockInfo.ForeColor = product.Stock > 10 ? System.Drawing.Color.LightGreen : 
                            (product.Stock > 0 ? System.Drawing.Color.Orange : System.Drawing.Color.Red);
                    }
                }
            }
        }

        private void AddToCart(ComboBox cmbProducts, NumericUpDown nudQuantity, DataGridView dgvCart)
        {
            if (cmbProducts.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(cmbProducts.SelectedValue);
            var product = Database.GetProductByNameOrCode(productId.ToString());

            if (product == null)
            {
                MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int quantity = Convert.ToInt32(nudQuantity.Value);
            if (quantity > product.Stock)
            {
                MessageBox.Show($"Insufficient stock.\nAvailable: {product.Stock} units", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cartItems.Rows.Add(productId, product.Name, quantity, product.Price, product.Price * quantity);
            RefreshCart(dgvCart);
            nudQuantity.Value = 1;
        }

        private void RefreshCart(DataGridView dgvCart)
        {
            dgvCart.Rows.Clear();
            totalAmount = 0;
            int itemCount = 0;

            foreach (DataRow row in cartItems.Rows)
            {
                decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                decimal total = Convert.ToDecimal(row["Total"]);
                int qty = Convert.ToInt32(row["Quantity"]);

                dgvCart.Rows.Add(
                    row["ProductName"],
                    qty,
                    $"{unitPrice:F2}",
                    $"{total:F2}"
                );
                totalAmount += total;
                itemCount += qty;
            }

            Label lblTotal = this.Controls.Find("lblTotalDisplay", true).Length > 0 ? 
                this.Controls.Find("lblTotalDisplay", true)[0] as Label : null;
            Label lblItemCount = this.Controls.Find("lblItemCount", true).Length > 0 ? 
                this.Controls.Find("lblItemCount", true)[0] as Label : null;

            if (lblTotal != null)
                lblTotal.Text = $"TOTAL: KES {totalAmount:F2}";
            if (lblItemCount != null)
                lblItemCount.Text = $"Items in Cart: {itemCount}";
        }

        private void ClearCart(DataGridView dgvCart)
        {
            if (cartItems.Rows.Count == 0) return;
            if (MessageBox.Show("Clear all items from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cartItems.Rows.Clear();
                RefreshCart(dgvCart);
            }
        }

        private void CompleteSale(DataGridView dgvCart, ComboBox cmbPayment, TextBox txtNotes, string cashierName)
        {
            if (cartItems.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items before completing sale.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPayment.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method.", "Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Complete sale for KES {totalAmount:F2}?\n\nPayment: {cmbPayment.SelectedItem}", "Confirm Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new MySqlConnection(Database.ConnectionString))
                    {
                        conn.Open();
                        int cashierId = GetCashierId(cashierName, conn);

                        if (cashierId == -1)
                        {
                            MessageBox.Show("Cashier not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Insert sale
                        string saleQuery = "INSERT INTO Sales (CashierId, TotalAmount, PaymentMethod, Notes) VALUES (@cashierId, @totalAmount, @paymentMethod, @notes); SELECT LAST_INSERT_ID();";
                        using (var cmd = new MySqlCommand(saleQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@cashierId", cashierId);
                            cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                            cmd.Parameters.AddWithValue("@paymentMethod", cmbPayment.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@notes", txtNotes.Text ?? "");

                            int saleId = Convert.ToInt32(cmd.ExecuteScalar());
                            lastSaleId = saleId;

                            // Insert sale items and update stock
                            foreach (DataRow row in cartItems.Rows)
                            {
                                string itemQuery = "INSERT INTO SaleItems (SaleId, ProductId, Quantity, UnitPrice, Total) VALUES (@saleId, @productId, @quantity, @unitPrice, @total)";
                                using (var itemCmd = new MySqlCommand(itemQuery, conn))
                                {
                                    itemCmd.Parameters.AddWithValue("@saleId", saleId);
                                    itemCmd.Parameters.AddWithValue("@productId", row["ProductId"]);
                                    itemCmd.Parameters.AddWithValue("@quantity", row["Quantity"]);
                                    itemCmd.Parameters.AddWithValue("@unitPrice", row["UnitPrice"]);
                                    itemCmd.Parameters.AddWithValue("@total", row["Total"]);
                                    itemCmd.ExecuteNonQuery();

                                    // Update product stock
                                    string stockQuery = "UPDATE Products SET Stock = Stock - @quantity WHERE Id = @productId";
                                    using (var stockCmd = new MySqlCommand(stockQuery, conn))
                                    {
                                        stockCmd.Parameters.AddWithValue("@quantity", row["Quantity"]);
                                        stockCmd.Parameters.AddWithValue("@productId", row["ProductId"]);
                                        stockCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    // Show receipt
                    ShowReceipt(cashierName);
                    ClearCart(dgvCart);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error completing sale: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowReceipt(string cashierName)
        {
            try
            {
                string[] receiptItems = new string[cartItems.Rows.Count];
                for (int i = 0; i < cartItems.Rows.Count; i++)
                {
                    var row = cartItems.Rows[i];
                    receiptItems[i] = $"{row["ProductName"]} - Qty: {row["Quantity"]} - Unit Price: KES {Convert.ToDecimal(row["UnitPrice"]):F2} - Subtotal: KES {Convert.ToDecimal(row["Total"]):F2}";
                }

                Receipt receiptForm = new Receipt(receiptItems, totalAmount, lastSaleId, cashierName);
                receiptForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCashierId(string username, MySqlConnection conn)
        {
            string query = "SELECT Id FROM Users WHERE Username = @username";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }

    // Helper class for ComboBox binding
    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Display { get; set; }
    }
}
