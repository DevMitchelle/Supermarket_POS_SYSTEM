using System.Data;
using MySql.Data.MySqlClient;

namespace POS_system
{
    public partial class UserManagement : Form
    {
        private int selectedUserId = -1;

        public UserManagement()
        {
            InitializeComponent();
            RefreshUserList();
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            ShowUserDialog(mode: "Add", userId: -1);
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }

            ShowUserDialog(mode: "Update", userId: selectedUserId);
        }

        private void BtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (POS_system.Database.DeleteUser(selectedUserId, out string message))
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserList();
                }
                else
                {
                    MessageBox.Show("Error: " + message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowUserDialog(string mode, int userId)
        {
            Form userForm = new Form();
            userForm.Text = $"{mode} User";
            userForm.Width = 400;
            userForm.Height = 320;
            userForm.StartPosition = FormStartPosition.CenterParent;
            userForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            userForm.MaximizeBox = false;
            userForm.MinimizeBox = false;

            // Username
            Label lblUsername = new Label() { Text = "Username:", Left = 20, Top = 20, Width = 100 };
            TextBox txtUsername = new TextBox() { Left = 150, Top = 20, Width = 200 };

            // Password
            Label lblPassword = new Label() { Text = "Password:", Left = 20, Top = 60, Width = 100 };
            TextBox txtPassword = new TextBox() { Left = 150, Top = 60, Width = 200, PasswordChar = '*' };

            // Role
            Label lblRole = new Label() { Text = "Role:", Left = 20, Top = 100, Width = 100 };
            ComboBox cmbRole = new ComboBox() { Left = 150, Top = 100, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRole.Items.AddRange(new[] { "Manager", "Cashier" });
            cmbRole.SelectedIndex = 0;

            // Buttons
            Button btnSave = new Button() { Text = "Save", Left = 150, Top = 200, Width = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Left = 250, Top = 200, Width = 80, DialogResult = DialogResult.Cancel };

            // Load existing data if updating
            if (mode == "Update")
            {
                LoadUserData(userId, txtUsername, txtPassword, cmbRole);
                txtUsername.ReadOnly = true; // Prevent changing username
            }

            btnSave.Click += (s, ev) =>
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = false;
                string message = "";

                if (mode == "Add")
                {
                    success = POS_system.Database.AddUser(txtUsername.Text, txtPassword.Text, cmbRole.SelectedItem.ToString(), out message);
                }
                else if (mode == "Update")
                {
                    success = POS_system.Database.UpdateUser(userId, txtUsername.Text, txtPassword.Text, cmbRole.SelectedItem.ToString(), out message);
                }

                if (success)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserList();
                    userForm.Close();
                }
                else
                {
                    MessageBox.Show("Error: " + message, "Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnCancel.Click += (s, ev) => userForm.Close();

            // Add all controls
            userForm.Controls.Add(lblUsername);
            userForm.Controls.Add(txtUsername);
            userForm.Controls.Add(lblPassword);
            userForm.Controls.Add(txtPassword);
            userForm.Controls.Add(lblRole);
            userForm.Controls.Add(cmbRole);
            userForm.Controls.Add(btnSave);
            userForm.Controls.Add(btnCancel);

            userForm.ShowDialog();
        }

        private void LoadUserData(int userId, TextBox txtUsername, TextBox txtPassword, ComboBox cmbRole)
        {
            try
            {
                using (var conn = new MySqlConnection(POS_system.Database.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Username, role FROM Users WHERE Id = @id";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtUsername.Text = reader["Username"].ToString();
                                cmbRole.SelectedItem = reader["role"].ToString();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshUserList()
        {
            try
            {
                DataTable users = POS_system.Database.GetUsers();
                if (users != null)
                {
                    selectedUserId = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}