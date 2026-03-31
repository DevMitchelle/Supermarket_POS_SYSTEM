namespace POS_system
{
    partial class ManagerDashboard
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
            lblWelcome = new Label();
            btnManageUsers = new Button();
            btnManageProducts = new Button();
            btnReports = new Button();
            btnSettings = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.FlatStyle = FlatStyle.Popup;
            lblWelcome.Font = new Font("Palatino Linotype", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.Aqua;
            lblWelcome.Location = new Point(166, 25);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(95, 27);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // btnManageUsers
            // 
            btnManageUsers.BackColor = Color.Silver;
            btnManageUsers.FlatStyle = FlatStyle.Popup;
            btnManageUsers.Font = new Font("Arial", 15F, FontStyle.Bold);
            btnManageUsers.ForeColor = Color.Black;
            btnManageUsers.Location = new Point(78, 98);
            btnManageUsers.Margin = new Padding(4, 3, 4, 3);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(175, 46);
            btnManageUsers.TabIndex = 1;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += BtnManageUsers_Click;
            // 
            // btnManageProducts
            // 
            btnManageProducts.BackColor = Color.Silver;
            btnManageProducts.FlatStyle = FlatStyle.Popup;
            btnManageProducts.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnManageProducts.ForeColor = Color.Black;
            btnManageProducts.Location = new Point(281, 99);
            btnManageProducts.Margin = new Padding(4, 3, 4, 3);
            btnManageProducts.Name = "btnManageProducts";
            btnManageProducts.Size = new Size(175, 46);
            btnManageProducts.TabIndex = 2;
            btnManageProducts.Text = "Manage Products";
            btnManageProducts.UseVisualStyleBackColor = false;
            btnManageProducts.Click += BtnManageProducts_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.Silver;
            btnReports.FlatStyle = FlatStyle.Popup;
            btnReports.Font = new Font("Arial", 14F, FontStyle.Bold);
            btnReports.ForeColor = Color.Black;
            btnReports.Location = new Point(185, 260);
            btnReports.Margin = new Padding(4, 3, 4, 3);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(175, 46);
            btnReports.TabIndex = 3;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += BtnReports_Click;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Silver;
            btnSettings.FlatStyle = FlatStyle.Popup;
            btnSettings.Font = new Font("Arial", 14F, FontStyle.Bold);
            btnSettings.ForeColor = Color.Black;
            btnSettings.Location = new Point(185, 173);
            btnSettings.Margin = new Padding(4, 3, 4, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(175, 46);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += BtnSettings_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.FlatStyle = FlatStyle.Popup;
            btnLogout.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(185, 362);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(175, 46);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // ManagerDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.ForestGreen;
            ClientSize = new Size(583, 554);
            Controls.Add(btnLogout);
            Controls.Add(btnSettings);
            Controls.Add(btnReports);
            Controls.Add(btnManageProducts);
            Controls.Add(btnManageUsers);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "ManagerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MANAGER DASHBOARD";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnLogout;
    }
}