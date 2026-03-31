using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace POS_system.Forms
{
    partial class Receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receipt));
            // Ensure the local DataGridViewCellStyle variable exists before use
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblReceiptNumber = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.pnlReceiptContainer = new System.Windows.Forms.Panel();
            this.dgvReceiptItems = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.btnSaveReceipt = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlReceiptContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle (store header)
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(30, 30, 30);
            this.lblTitle.Location = new Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(220, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "POS System Receipt";
            // 
            // lblReceiptNumber
            // 
            lblReceiptNumber.AutoSize = true;
            lblReceiptNumber.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblReceiptNumber.ForeColor = Color.Black;
            lblReceiptNumber.Location = new Point(259, 49);
            lblReceiptNumber.Margin = new Padding(4, 0, 4, 0);
            lblReceiptNumber.Name = "lblReceiptNumber";
            lblReceiptNumber.Size = new Size(112, 25);
            lblReceiptNumber.TabIndex = 1;
            lblReceiptNumber.Text = "Receipt #: 0";
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDateTime.ForeColor = Color.White;
            lblDateTime.Location = new Point(96, 90);
            lblDateTime.Margin = new Padding(4, 0, 4, 0);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(102, 25);
            lblDateTime.TabIndex = 2;
            lblDateTime.Text = "Date/Time";
            // 
            // pnlReceiptContainer
            // 
            pnlReceiptContainer.BackColor = Color.White;
            pnlReceiptContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlReceiptContainer.Controls.Add(dgvReceiptItems);
            pnlReceiptContainer.Location = new Point(12, 127);
            pnlReceiptContainer.Margin = new Padding(4, 3, 4, 3);
            pnlReceiptContainer.Name = "pnlReceiptContainer";
            pnlReceiptContainer.Size = new Size(793, 369);
            pnlReceiptContainer.TabIndex = 3;
            // 
            // dgvReceiptItems
            // 
            dgvReceiptItems.AllowUserToAddRows = false;
            dgvReceiptItems.AllowUserToDeleteRows = false;
            dgvReceiptItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReceiptItems.BackgroundColor = Color.DarkOliveGreen;
            dgvReceiptItems.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DimGray;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvReceiptItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvReceiptItems.ColumnHeadersHeight = 30;
            dgvReceiptItems.Dock = DockStyle.Fill;
            dgvReceiptItems.EnableHeadersVisualStyles = false;
            dgvReceiptItems.GridColor = Color.LightGray;
            dgvReceiptItems.Location = new Point(0, 0);
            dgvReceiptItems.Margin = new Padding(4, 3, 4, 3);
            dgvReceiptItems.Name = "dgvReceiptItems";
            dgvReceiptItems.ReadOnly = true;
            dgvReceiptItems.RowHeadersVisible = false;
            dgvReceiptItems.Size = new Size(791, 367);
            dgvReceiptItems.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.Gold;
            lblTotal.Location = new Point(587, 517);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(106, 22);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: 0.00";
            // 
            // btnPrintReceipt
            // 
            btnPrintReceipt.BackColor = Color.SteelBlue;
            btnPrintReceipt.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnPrintReceipt.ForeColor = Color.White;
            btnPrintReceipt.Location = new Point(34, 547);
            btnPrintReceipt.Margin = new Padding(4, 3, 4, 3);
            btnPrintReceipt.Name = "btnPrintReceipt";
            btnPrintReceipt.Size = new Size(140, 40);
            btnPrintReceipt.TabIndex = 5;
            btnPrintReceipt.Text = "🖨 Print Receipt";
            btnPrintReceipt.UseVisualStyleBackColor = false;
            btnPrintReceipt.Click += BtnPrintReceipt_Click;
            // 
            // btnSaveReceipt
            // 
            btnSaveReceipt.BackColor = Color.DarkGreen;
            btnSaveReceipt.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnSaveReceipt.ForeColor = Color.White;
            btnSaveReceipt.Location = new Point(190, 547);
            btnSaveReceipt.Margin = new Padding(4, 3, 4, 3);
            btnSaveReceipt.Name = "btnSaveReceipt";
            btnSaveReceipt.Size = new Size(140, 40);
            btnSaveReceipt.TabIndex = 5;
            btnSaveReceipt.Text = "💾 Save Receipt";
            btnSaveReceipt.UseVisualStyleBackColor = false;
            btnSaveReceipt.Click += BtnSaveReceipt_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(372, 547);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 40);
            btnClose.TabIndex = 6;
            btnClose.Text = "✕ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // Receipt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Firebrick;
            ClientSize = new Size(817, 599);
            Controls.Add(btnClose);
            Controls.Add(btnSaveReceipt);
            Controls.Add(btnPrintReceipt);
            Controls.Add(lblTotal);
            Controls.Add(pnlReceiptContainer);
            Controls.Add(lblDateTime);
            Controls.Add(lblReceiptNumber);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Receipt";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipt";
            pnlReceiptContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReceiptItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReceiptNumber;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel pnlReceiptContainer;
        private System.Windows.Forms.DataGridView dgvReceiptItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.Button btnSaveReceipt;
        private System.Windows.Forms.Button btnClose;
    }
}