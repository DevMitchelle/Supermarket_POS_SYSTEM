namespace POS_system.Forms
{
    public partial class CustomerSalesView : Form
    {
        private List<SaleItem> cartItems = new List<SaleItem>();

        public CustomerSalesView()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Uses centralized Database helper
            dgvProducts.DataSource = POS_system.Database.GetProducts();
        }

        private void BtnViewCart_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty.");
                return;
            }

            // Here you can show cart details or checkout form
            MessageBox.Show($"Items in cart: {cartItems.Count}\nTotal: {CalculateTotal():C}");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.Subtotal;
            }
            return total;
        }
    }
}
