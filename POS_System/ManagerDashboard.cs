using POS_system.Forms;

namespace POS_system
{
    public partial class ManagerDashboard : Form
    {
        private string managerName = "Unknown";

        public ManagerDashboard()
        {
            InitializeComponent();
        }

        public ManagerDashboard(string username)
        {
            managerName = username;
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {username}";
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

        private void BtnManageUsers_Click(object sender, EventArgs e)
        {
            new UserManagement().Show();
        }

        private void BtnManageProducts_Click(object sender, EventArgs e)
        {
            new ProductManagement().Show();
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            new Report().Show();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            new Settings().Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}