namespace POS_system
{
    public partial class ProductManagement : Form
    {
        private int selectedProductId = -1;

        public ProductManagement()
        {
            InitializeComponent();
            RefreshProductList();
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedProductId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["id"].Value);
                txtName.Text = dgvProducts.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtPrice.Text = dgvProducts.Rows[e.RowIndex].Cells["price"].Value.ToString();
                txtStock.Text = dgvProducts.Rows[e.RowIndex].Cells["stock"].Value.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Fill all fields.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Invalid price or stock value.");
                return;
            }

            if (POS_system.Database.AddProduct(txtName.Text, price, stock, out string message))
            {
                MessageBox.Show(message);
                ClearFields();
                RefreshProductList();
            }
            else
            {
                MessageBox.Show("Error: " + message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Select a product to update.");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Fill all fields.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Invalid price or stock value.");
                return;
            }

            if (POS_system.Database.UpdateProduct(selectedProductId, txtName.Text, price, stock, out string message))
            {
                MessageBox.Show(message);
                ClearFields();
                RefreshProductList();
            }
            else
            {
                MessageBox.Show("Error: " + message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1)
            {
                MessageBox.Show("Select a product to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (POS_system.Database.DeleteProduct(selectedProductId, out string message))
                {
                    MessageBox.Show(message);
                    ClearFields();
                    RefreshProductList();
                }
                else
                {
                    MessageBox.Show("Error: " + message);
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProductList();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshProductList()
        {
            dgvProducts.DataSource = POS_system.Database.GetProducts();
            selectedProductId = -1;
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            selectedProductId = -1;
        }
    }
}
