namespace POS_system
{
    partial class Settings
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
            btnChangePassword = new Button();
            btnSystemConfig = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(233, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(86, 22);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Settings";
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.DarkSlateBlue;
            btnChangePassword.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(233, 115);
            btnChangePassword.Margin = new Padding(4, 3, 4, 3);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(175, 46);
            btnChangePassword.TabIndex = 1;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += BtnChangePassword_Click;
            // 
            // btnSystemConfig
            // 
            btnSystemConfig.BackColor = Color.Indigo;
            btnSystemConfig.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnSystemConfig.ForeColor = Color.White;
            btnSystemConfig.Location = new Point(233, 185);
            btnSystemConfig.Margin = new Padding(4, 3, 4, 3);
            btnSystemConfig.Name = "btnSystemConfig";
            btnSystemConfig.Size = new Size(175, 46);
            btnSystemConfig.TabIndex = 2;
            btnSystemConfig.Text = "System Config";
            btnSystemConfig.UseVisualStyleBackColor = false;
            btnSystemConfig.Click += BtnSystemConfig_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(233, 254);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(175, 46);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Back";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            ClientSize = new Size(642, 519);
            Controls.Add(btnLogout);
            Controls.Add(btnSystemConfig);
            Controls.Add(btnChangePassword);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnSystemConfig;
        private System.Windows.Forms.Button btnLogout;
    }
}