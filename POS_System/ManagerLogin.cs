namespace POS_system
{
    // Minimal modal manager-only login dialog (programmatic UI)
    public class ManagerLogin : Form
    {
        private Label lblUser;
        private TextBox txtUsername;
        private Label lblPass;
        private TextBox txtPassword;
        private Button btnOk;
        private Button btnCancel;

        public ManagerLogin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Manager Authorization";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(320, 150);
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblUser = new Label() { Text = "Username:", Location = new Point(12, 15), AutoSize = true };
            txtUsername = new TextBox() { Location = new Point(100, 12), Width = 200 };

            lblPass = new Label() { Text = "Password:", Location = new Point(12, 50), AutoSize = true };
            txtPassword = new TextBox() { Location = new Point(100, 47), Width = 200, UseSystemPasswordChar = true };

            btnOk = new Button() { Text = "OK", Location = new Point(140, 95), DialogResult = DialogResult.None };
            btnOk.Click += BtnOk_Click;

            btnCancel = new Button() { Text = "Cancel", Location = new Point(225, 95), DialogResult = DialogResult.Cancel };

            this.Controls.Add(lblUser);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Enter manager username and password.", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = Auth.AuthenticateUser(username, password);

            if (role == "Manager")
            {
                // Open ManagerDashboard; do not close cashier unless caller chooses so
                ManagerDashboard managerForm = new ManagerDashboard(username);
                managerForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid manager credentials.", "Authorization Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
