namespace POS_system
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = Auth.AuthenticateUser(username, password);

            if (string.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Welcome Manager\n\nLogged in as: {username}", "Successful Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                ManagerDashboard managerForm = new ManagerDashboard(username);
                managerForm.Show();
            }
            else if (string.Equals(role, "Cashier", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"Welcome Cashier\n\nLogged in as: {username}", "Successful Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                CashierDashboard cashierForm = new CashierDashboard(username);
                cashierForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.\n\nPlease try again.", "Failed Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
