using System;
using System.Windows.Forms;
using System.Drawing;

namespace POS_system
{
    partial class CashierDashboard
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
            btnNewSale = new Button();
            btnViewReceipts = new Button();
            btnManager = new Button();
            btnCustomerView = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Location = new Point(147, 35);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(110, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome";
            // 
            // btnNewSale
            // 
            btnNewSale.BackColor = Color.Brown;
            btnNewSale.FlatAppearance.BorderColor = Color.Black;
            btnNewSale.FlatStyle = FlatStyle.Popup;
            btnNewSale.Font = new Font("Cambria", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewSale.ForeColor = Color.White;
            btnNewSale.Location = new Point(52, 133);
            btnNewSale.Margin = new Padding(4, 3, 4, 3);
            btnNewSale.Name = "btnNewSale";
            btnNewSale.Size = new Size(140, 46);
            btnNewSale.TabIndex = 1;
            btnNewSale.Text = "New Sale";
            btnNewSale.UseVisualStyleBackColor = false;
            btnNewSale.Click += BtnNewSale_Click;
            // 
            // btnViewReceipts
            // 
            btnViewReceipts.BackColor = Color.Brown;
            btnViewReceipts.FlatAppearance.BorderColor = Color.Gold;
            btnViewReceipts.FlatAppearance.BorderSize = 20;
            btnViewReceipts.FlatStyle = FlatStyle.Popup;
            btnViewReceipts.Font = new Font("Cambria", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewReceipts.ForeColor = Color.White;
            btnViewReceipts.Location = new Point(301, 133);
            btnViewReceipts.Margin = new Padding(4, 3, 4, 3);
            btnViewReceipts.Name = "btnViewReceipts";
            btnViewReceipts.Size = new Size(140, 46);
            btnViewReceipts.TabIndex = 2;
            btnViewReceipts.Text = "View Receipts";
            btnViewReceipts.UseVisualStyleBackColor = false;
            btnViewReceipts.Click += BtnViewReceipts_Click;
            // 
            // btnManager
            // 
            btnManager.BackColor = Color.Brown;
            btnManager.FlatStyle = FlatStyle.Popup;
            btnManager.Font = new Font("Cambria", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManager.ForeColor = Color.White;
            btnManager.Location = new Point(301, 217);
            btnManager.Margin = new Padding(4, 3, 4, 3);
            btnManager.Name = "btnManager";
            btnManager.Size = new Size(140, 46);
            btnManager.TabIndex = 4;
            btnManager.Text = "Manager";
            btnManager.UseVisualStyleBackColor = false;
            btnManager.Click += BtnManager_Click;
            // 
            // btnCustomerView
            // 
            btnCustomerView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnCustomerView.BackColor = Color.Brown;
            btnCustomerView.FlatAppearance.BorderColor = Color.Yellow;
            btnCustomerView.FlatStyle = FlatStyle.Popup;
            btnCustomerView.Font = new Font("Cambria", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCustomerView.ForeColor = Color.White;
            btnCustomerView.Location = new Point(52, 217);
            btnCustomerView.Margin = new Padding(4, 3, 4, 3);
            btnCustomerView.Name = "btnCustomerView";
            btnCustomerView.Size = new Size(140, 46);
            btnCustomerView.TabIndex = 5;
            btnCustomerView.Text = "Customer View";
            btnCustomerView.UseVisualStyleBackColor = false;
            btnCustomerView.Click += BtnCustomerView_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Red;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.Black;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.Black;
            btnLogout.FlatStyle = FlatStyle.Popup;
            btnLogout.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(159, 333);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 46);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // CashierDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            ClientSize = new Size(583, 550);
            Controls.Add(btnLogout);
            Controls.Add(btnCustomerView);
            Controls.Add(btnManager);
            Controls.Add(btnViewReceipts);
            Controls.Add(btnNewSale);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "CashierDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cashier Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNewSale;
        private System.Windows.Forms.Button btnViewReceipts;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnCustomerView;
        private System.Windows.Forms.Button btnLogout;
    }
}