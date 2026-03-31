namespace POS_system
{
    partial class UserManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnAddUser = new Button();
            btnUpdateUser = new Button();
            btnDeleteUser = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(175, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(143, 22);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Users";
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.DarkGoldenrod;
            btnAddUser.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(41, 118);
            btnAddUser.Margin = new Padding(4, 3, 4, 3);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(140, 46);
            btnAddUser.TabIndex = 1;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += BtnAddUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.BackColor = Color.DarkSlateGray;
            btnUpdateUser.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnUpdateUser.ForeColor = Color.White;
            btnUpdateUser.Location = new Point(222, 118);
            btnUpdateUser.Margin = new Padding(4, 3, 4, 3);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(140, 46);
            btnUpdateUser.TabIndex = 2;
            btnUpdateUser.Text = "Update User";
            btnUpdateUser.UseVisualStyleBackColor = false;
            btnUpdateUser.Click += BtnUpdateUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.Red;
            btnDeleteUser.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(384, 118);
            btnDeleteUser.Margin = new Padding(4, 3, 4, 3);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(140, 46);
            btnDeleteUser.TabIndex = 3;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(222, 273);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 46);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Back";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // UserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(583, 519);
            Controls.Add(btnLogout);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnAddUser);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "UserManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Management";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnLogout;
    }
}