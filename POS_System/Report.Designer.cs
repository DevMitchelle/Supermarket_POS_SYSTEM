using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace POS_system.Forms
{
    partial class Report
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
            btnSalesReport = new Button();
            btnInventoryReport = new Button();
            btnBack = new Button();
            pnlReportContainer = new Panel();
            dgvSalesReport = new DataGridView();
            dgvInventoryReport = new DataGridView();
            btnExport = new Button();
            lblTotalSales = new Label();
            pnlReportContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(415, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(83, 22);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reports";
            // 
            // btnSalesReport
            // 
            btnSalesReport.BackColor = Color.Goldenrod;
            btnSalesReport.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnSalesReport.ForeColor = Color.White;
            btnSalesReport.Location = new Point(276, 58);
            btnSalesReport.Margin = new Padding(4, 3, 4, 3);
            btnSalesReport.Name = "btnSalesReport";
            btnSalesReport.Size = new Size(152, 46);
            btnSalesReport.TabIndex = 1;
            btnSalesReport.Text = "Sales Report";
            btnSalesReport.UseVisualStyleBackColor = false;
            btnSalesReport.Click += BtnSalesReport_Click;
            // 
            // btnInventoryReport
            // 
            btnInventoryReport.BackColor = Color.Orchid;
            btnInventoryReport.Font = new Font("Arial", 12F, FontStyle.Bold);
            btnInventoryReport.ForeColor = Color.White;
            btnInventoryReport.Location = new Point(475, 58);
            btnInventoryReport.Margin = new Padding(4, 3, 4, 3);
            btnInventoryReport.Name = "btnInventoryReport";
            btnInventoryReport.Size = new Size(152, 46);
            btnInventoryReport.TabIndex = 2;
            btnInventoryReport.Text = "Inventory Report";
            btnInventoryReport.UseVisualStyleBackColor = false;
            btnInventoryReport.Click += BtnInventoryReport_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Crimson;
            btnBack.Font = new Font("Arial", 13F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(653, 58);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(152, 46);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnLogout_Click;
            // 
            // pnlReportContainer
            // 
            pnlReportContainer.BackColor = Color.White;
            pnlReportContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlReportContainer.Controls.Add(dgvSalesReport);
            pnlReportContainer.Controls.Add(dgvInventoryReport);
            pnlReportContainer.Location = new Point(12, 127);
            pnlReportContainer.Margin = new Padding(4, 3, 4, 3);
            pnlReportContainer.Name = "pnlReportContainer";
            pnlReportContainer.Size = new Size(1143, 519);
            pnlReportContainer.TabIndex = 4;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesReport.BackgroundColor = Color.Crimson;
            dgvSalesReport.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(128, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.RosyBrown;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSalesReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSalesReport.ColumnHeadersHeight = 30;
            dgvSalesReport.Dock = DockStyle.Fill;
            dgvSalesReport.EnableHeadersVisualStyles = false;
            dgvSalesReport.GridColor = Color.LightGray;
            dgvSalesReport.Location = new Point(0, 0);
            dgvSalesReport.Margin = new Padding(4, 3, 4, 3);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.RowHeadersVisible = false;
            dgvSalesReport.Size = new Size(1141, 517);
            dgvSalesReport.TabIndex = 0;
            dgvSalesReport.Visible = false;
            // 
            // dgvInventoryReport
            // 
            dgvInventoryReport.AllowUserToAddRows = false;
            dgvInventoryReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventoryReport.BackgroundColor = Color.White;
            dgvInventoryReport.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(70, 130, 180);
            dataGridViewCellStyle2.Font = new Font("Arial", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInventoryReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInventoryReport.ColumnHeadersHeight = 30;
            dgvInventoryReport.Dock = DockStyle.Fill;
            dgvInventoryReport.EnableHeadersVisualStyles = false;
            dgvInventoryReport.GridColor = Color.LightGray;
            dgvInventoryReport.Location = new Point(0, 0);
            dgvInventoryReport.Margin = new Padding(4, 3, 4, 3);
            dgvInventoryReport.Name = "dgvInventoryReport";
            dgvInventoryReport.ReadOnly = true;
            dgvInventoryReport.RowHeadersVisible = false;
            dgvInventoryReport.Size = new Size(1141, 517);
            dgvInventoryReport.TabIndex = 1;
            dgvInventoryReport.Visible = false;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.SteelBlue;
            btnExport.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(368, 676);
            btnExport.Margin = new Padding(4, 3, 4, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(152, 40);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export to CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Visible = false;
            btnExport.Click += BtnExport_Click;
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("Arial", 13F, FontStyle.Bold);
            lblTotalSales.ForeColor = Color.Gold;
            lblTotalSales.Location = new Point(720, 663);
            lblTotalSales.Margin = new Padding(4, 0, 4, 0);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(152, 21);
            lblTotalSales.TabIndex = 6;
            lblTotalSales.Text = "Total Sales: 0.00";
            lblTotalSales.Visible = false;
            // 
            // Report
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Indigo;
            ClientSize = new Size(1167, 728);
            Controls.Add(lblTotalSales);
            Controls.Add(btnExport);
            Controls.Add(pnlReportContainer);
            Controls.Add(btnBack);
            Controls.Add(btnInventoryReport);
            Controls.Add(btnSalesReport);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Report";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Report";
            pnlReportContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.Button btnInventoryReport;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlReportContainer;
        private System.Windows.Forms.DataGridView dgvSalesReport;
        private System.Windows.Forms.DataGridView dgvInventoryReport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblTotalSales;
    }
}