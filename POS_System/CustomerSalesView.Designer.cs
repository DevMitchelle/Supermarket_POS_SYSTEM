using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS_system.Forms
{
    partial class CustomerSalesView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitle = new Label();
            pnlProductContainer = new Panel();
            dgvProducts = new DataGridView();
            btnViewCart = new Button();
            btnExit = new Button();
            pnlProductContainer.SuspendLayout();
            ((ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(292, 12);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(182, 22);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Products Available";
            // 
            // pnlProductContainer
            // 
            pnlProductContainer.BackColor = Color.White;
            pnlProductContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlProductContainer.Controls.Add(dgvProducts);
            pnlProductContainer.Location = new Point(12, 58);
            pnlProductContainer.Margin = new Padding(4, 3, 4, 3);
            pnlProductContainer.Name = "pnlProductContainer";
            pnlProductContainer.Size = new Size(910, 404);
            pnlProductContainer.TabIndex = 1;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 0);
            dataGridViewCellStyle1.Font = new Font("Microsoft Tai Le", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 64, 0);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProducts.BackgroundColor = Color.Silver;
            dgvProducts.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(70, 130, 180);
            dataGridViewCellStyle2.Font = new Font("Arial", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProducts.ColumnHeadersHeight = 30;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.GridColor = Color.LightGray;
            dgvProducts.Location = new Point(0, 0);
            dgvProducts.Margin = new Padding(4, 3, 4, 3);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(908, 402);
            dgvProducts.TabIndex = 0;
            // 
            // btnViewCart
            // 
            btnViewCart.BackColor = Color.DarkGreen;
            btnViewCart.FlatStyle = FlatStyle.Popup;
            btnViewCart.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnViewCart.ForeColor = Color.White;
            btnViewCart.Location = new Point(292, 485);
            btnViewCart.Margin = new Padding(4, 3, 4, 3);
            btnViewCart.Name = "btnViewCart";
            btnViewCart.Size = new Size(140, 40);
            btnViewCart.TabIndex = 2;
            btnViewCart.Text = "View Cart";
            btnViewCart.UseVisualStyleBackColor = false;
            btnViewCart.Click += BtnViewCart_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(502, 485);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(140, 40);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // CustomerSalesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkRed;
            ClientSize = new Size(949, 545);
            Controls.Add(btnExit);
            Controls.Add(btnViewCart);
            Controls.Add(pnlProductContainer);
            Controls.Add(lblTitle);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "CustomerSalesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Sales View";
            pnlProductContainer.ResumeLayout(false);
            ((ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlProductContainer;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Button btnViewCart;
        private System.Windows.Forms.Button btnExit;
    }
}