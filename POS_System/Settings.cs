using MySql.Data.MySqlClient;

namespace POS_system
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            Form changePasswordForm = new Form();
            changePasswordForm.Text = "Change Password";
            changePasswordForm.Width = 400;
            changePasswordForm.Height = 300;
            changePasswordForm.StartPosition = FormStartPosition.CenterParent;

            Label lblUsername = new Label() { Text = "Username:", Left = 20, Top = 20, Width = 100 };
            TextBox txtUsername = new TextBox() { Left = 150, Top = 20, Width = 200 };

            Label lblOldPassword = new Label() { Text = "Old Password:", Left = 20, Top = 60, Width = 100 };
            TextBox txtOldPassword = new TextBox() { Left = 150, Top = 60, Width = 200, PasswordChar = '*' };

            Label lblNewPassword = new Label() { Text = "New Password:", Left = 20, Top = 100, Width = 100 };
            TextBox txtNewPassword = new TextBox() { Left = 150, Top = 100, Width = 200, PasswordChar = '*' };

            Label lblConfirmPassword = new Label() { Text = "Confirm Password:", Left = 20, Top = 140, Width = 100 };
            TextBox txtConfirmPassword = new TextBox() { Left = 150, Top = 140, Width = 200, PasswordChar = '*' };

            Button btnSave = new Button() { Text = "Save", Left = 150, Top = 200, Width = 80 };
            Button btnCancel = new Button() { Text = "Cancel", Left = 250, Top = 200, Width = 80 };

            btnSave.Click += (s, ev) =>
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtOldPassword.Text) ||
                    string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("New passwords do not match.");
                    return;
                }

                if (POS_system.Database.ChangePassword(txtUsername.Text, txtOldPassword.Text, txtNewPassword.Text, out string message))
                {
                    MessageBox.Show(message);
                    changePasswordForm.Close();
                }
                else
                {
                    MessageBox.Show("Error: " + message);
                }
            };

            btnCancel.Click += (s, ev) => changePasswordForm.Close();

            changePasswordForm.Controls.Add(lblUsername);
            changePasswordForm.Controls.Add(txtUsername);
            changePasswordForm.Controls.Add(lblOldPassword);
            changePasswordForm.Controls.Add(txtOldPassword);
            changePasswordForm.Controls.Add(lblNewPassword);
            changePasswordForm.Controls.Add(txtNewPassword);
            changePasswordForm.Controls.Add(lblConfirmPassword);
            changePasswordForm.Controls.Add(txtConfirmPassword);
            changePasswordForm.Controls.Add(btnSave);
            changePasswordForm.Controls.Add(btnCancel);

            changePasswordForm.ShowDialog();
        }

        private void BtnSystemConfig_Click(object sender, EventArgs e)
        {
            Form systemConfigForm = new Form();
            systemConfigForm.Text = "System Configuration";
            systemConfigForm.Width = 500;
            systemConfigForm.Height = 350;
            systemConfigForm.StartPosition = FormStartPosition.CenterParent;

            Label lblDatabaseServer = new Label() { Text = "Database Server:", Left = 20, Top = 20, Width = 120 };
            TextBox txtDatabaseServer = new TextBox() { Left = 150, Top = 20, Width = 300, Text = "localhost" };

            Label lblDatabaseName = new Label() { Text = "Database Name:", Left = 20, Top = 60, Width = 120 };
            TextBox txtDatabaseName = new TextBox() { Left = 150, Top = 60, Width = 300, Text = "pos_db" };

            Label lblDatabaseUser = new Label() { Text = "Database User:", Left = 20, Top = 100, Width = 120 };
            TextBox txtDatabaseUser = new TextBox() { Left = 150, Top = 100, Width = 300, Text = "root" };

            Label lblDatabasePassword = new Label() { Text = "Database Password:", Left = 20, Top = 140, Width = 120 };
            TextBox txtDatabasePassword = new TextBox() { Left = 150, Top = 140, Width = 300, PasswordChar = '*' };

            Label lblInfo = new Label() { Text = "Update these settings to configure the database connection.", Left = 20, Top = 180, Width = 400 };

            Button btnSave = new Button() { Text = "Save", Left = 200, Top = 250, Width = 80 };
            Button btnCancel = new Button() { Text = "Cancel", Left = 300, Top = 250, Width = 80 };

            btnSave.Click += (s, ev) =>
            {
                string connectionString = $"server={txtDatabaseServer.Text};database={txtDatabaseName.Text};uid={txtDatabaseUser.Text};pwd={txtDatabasePassword.Text};";
                try
                {
                    using (MySqlConnection testConn = new MySqlConnection(connectionString))
                    {
                        testConn.Open();
                        MessageBox.Show("Connection successful! Settings saved.");
                        POS_system.Database.ConnectionString = connectionString;
                        systemConfigForm.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message);
                }
            };

            btnCancel.Click += (s, ev) => systemConfigForm.Close();

            systemConfigForm.Controls.Add(lblDatabaseServer);
            systemConfigForm.Controls.Add(txtDatabaseServer);
            systemConfigForm.Controls.Add(lblDatabaseName);
            systemConfigForm.Controls.Add(txtDatabaseName);
            systemConfigForm.Controls.Add(lblDatabaseUser);
            systemConfigForm.Controls.Add(txtDatabaseUser);
            systemConfigForm.Controls.Add(lblDatabasePassword);
            systemConfigForm.Controls.Add(txtDatabasePassword);
            systemConfigForm.Controls.Add(lblInfo);
            systemConfigForm.Controls.Add(btnSave);
            systemConfigForm.Controls.Add(btnCancel);

            systemConfigForm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}