using POS_system.Forms;
using POS_system; // Or the correct namespace where Sales is defined

namespace POS_system
{
    public partial class CashierDashboard : Form
    {
        private string username;

        public CashierDashboard()
        {
            InitializeComponent();
        }

        public CashierDashboard(string user)
        {
            username = user;
            InitializeComponent();
            lblTitle.Text = $"Welcome, {username}";
            LoadBackgroundImage();
        }

        private void LoadBackgroundImage()
        {
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\Users\mitch\OneDrive\Desktop\POS_SYSTEM\manager.jpeg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                // Continue without background image
            }
        }

        private void BtnNewSale_Click(object sender, EventArgs e)
        {
            new Sales(username).Show();
        }

        private void BtnViewReceipts_Click(object sender, EventArgs e)
        {
            new Receipt().Show();
        }

        private void BtnManager_Click(object sender, EventArgs e)
        {
            // Open a manager-only authorization dialog. ManagerLogin uses Auth.AuthenticateUser and only proceeds on Manager role.
            using (var dlg = new ManagerLogin())
            {
                dlg.ShowDialog(this);
            }
        }

        private void BtnCustomerView_Click(object sender, EventArgs e)
        {
            new CustomerSalesView().Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
