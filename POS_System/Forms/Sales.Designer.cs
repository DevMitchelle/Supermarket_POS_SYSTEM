using System.Windows.Forms;
using System.Drawing;

namespace POS_system.Forms
{
    partial class Sales
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel pnlTop;
        private Label lblProductSection;
        public ComboBox cmbProducts;
        private Label lblQuantityLabel;
        public NumericUpDown nudQuantity;
        private Button btnAddToCart;
        private Label lblStockInfo;
        private Label lblPaymentSection;
        private Label lblPaymentLabel;
        public ComboBox cmbPayment;
        private Label lblNotesLabel;
        public TextBox txtNotes;
        private Label lblTotalDisplay;
        private Panel pnlCart;
        private Label lblCartTitle;
        public DataGridView dgvCart;
        private Panel pnlButtons;
        private Button btnCompleteSale;
        private Button btnClear;
        private Button btnClose;
        private Label lblItemCount;

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
            lblTitle = new Label();
            pnlTop = new Panel();
            lblProductSection = new Label();
            cmbProducts = new ComboBox();
            lblQuantityLabel = new Label();
            nudQuantity = new NumericUpDown();
            btnAddToCart = new Button();
            lblStockInfo = new Label();
            lblPaymentSection = new Label();
            lblPaymentLabel = new Label();
            cmbPayment = new ComboBox();
            lblNotesLabel = new Label();
            txtNotes = new TextBox();
            lblTotalDisplay = new Label();
            lblCartTitle = new Label();
            pnlCart = new Panel();
            dgvCart = new DataGridView();
            colProduct = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();
            pnlButtons = new Panel();
            btnCompleteSale = new Button();
            btnClear = new Button();
            btnClose = new Button();
            lblItemCount = new Label();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            pnlCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Cambria", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(247, 26);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Point of Sale - New Sale";
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(70, 70, 70);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(lblProductSection);
            pnlTop.Controls.Add(cmbProducts);
            pnlTop.Controls.Add(lblQuantityLabel);
            pnlTop.Controls.Add(nudQuantity);
            pnlTop.Controls.Add(btnAddToCart);
            pnlTop.Controls.Add(lblStockInfo);
            pnlTop.Controls.Add(lblPaymentSection);
            pnlTop.Controls.Add(lblPaymentLabel);
            pnlTop.Controls.Add(cmbPayment);
            pnlTop.Controls.Add(lblNotesLabel);
            pnlTop.Controls.Add(txtNotes);
            pnlTop.Controls.Add(lblTotalDisplay);
            pnlTop.Location = new Point(15, 50);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1150, 280);
            pnlTop.TabIndex = 1;
            // 
            // lblProductSection
            // 
            lblProductSection.AutoSize = true;
            lblProductSection.Font = new Font("Cambria", 11F, FontStyle.Bold);
            lblProductSection.ForeColor = Color.Gold;
            lblProductSection.Location = new Point(20, 15);
            lblProductSection.Name = "lblProductSection";
            lblProductSection.Size = new Size(133, 17);
            lblProductSection.TabIndex = 2;
            lblProductSection.Text = "SELECT PRODUCT";
            // 
            // cmbProducts
            // 
            cmbProducts.BackColor = Color.White;
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.Font = new Font("Cambria", 10F);
            cmbProducts.Location = new Point(20, 40);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(520, 23);
            cmbProducts.TabIndex = 3;
            // 
            // lblQuantityLabel
            // 
            lblQuantityLabel.AutoSize = true;
            lblQuantityLabel.Font = new Font("Cambria", 9F, FontStyle.Bold);
            lblQuantityLabel.ForeColor = Color.White;
            lblQuantityLabel.Location = new Point(20, 80);
            lblQuantityLabel.Name = "lblQuantityLabel";
            lblQuantityLabel.Size = new Size(56, 14);
            lblQuantityLabel.TabIndex = 4;
            lblQuantityLabel.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            nudQuantity.Font = new Font("Cambria", 10F);
            nudQuantity.Location = new Point(20, 100);
            nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(100, 23);
            nudQuantity.TabIndex = 5;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.Brown;
            btnAddToCart.FlatStyle = FlatStyle.Popup;
            btnAddToCart.Font = new Font("Cambria", 11F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(20, 150);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(520, 40);
            btnAddToCart.TabIndex = 6;
            btnAddToCart.Text = "ADD TO CART";
            btnAddToCart.UseVisualStyleBackColor = false;
            // 
            // lblStockInfo
            // 
            lblStockInfo.Font = new Font("Cambria", 8F);
            lblStockInfo.ForeColor = Color.LightGray;
            lblStockInfo.Location = new Point(20, 205);
            lblStockInfo.Name = "lblStockInfo";
            lblStockInfo.Size = new Size(520, 20);
            lblStockInfo.TabIndex = 7;
            lblStockInfo.Text = "Stock: 0";
            // 
            // lblPaymentSection
            // 
            lblPaymentSection.AutoSize = true;
            lblPaymentSection.Font = new Font("Cambria", 11F, FontStyle.Bold);
            lblPaymentSection.ForeColor = Color.Gold;
            lblPaymentSection.Location = new Point(570, 15);
            lblPaymentSection.Name = "lblPaymentSection";
            lblPaymentSection.Size = new Size(129, 17);
            lblPaymentSection.TabIndex = 8;
            lblPaymentSection.Text = "PAYMENT & NOTES";
            // 
            // lblPaymentLabel
            // 
            lblPaymentLabel.AutoSize = true;
            lblPaymentLabel.Font = new Font("Cambria", 9F, FontStyle.Bold);
            lblPaymentLabel.ForeColor = Color.White;
            lblPaymentLabel.Location = new Point(570, 40);
            lblPaymentLabel.Name = "lblPaymentLabel";
            lblPaymentLabel.Size = new Size(101, 14);
            lblPaymentLabel.TabIndex = 9;
            lblPaymentLabel.Text = "Payment Method:";
            // 
            // cmbPayment
            // 
            cmbPayment.BackColor = Color.White;
            cmbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayment.Font = new Font("Cambria", 10F);
            cmbPayment.Items.AddRange(new object[] { "Cash", "Card", "Mobile Money", "Cheque" });
            cmbPayment.Location = new Point(570, 60);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(550, 23);
            cmbPayment.TabIndex = 10;
            // 
            // lblNotesLabel
            // 
            lblNotesLabel.AutoSize = true;
            lblNotesLabel.Font = new Font("Cambria", 9F, FontStyle.Bold);
            lblNotesLabel.ForeColor = Color.White;
            lblNotesLabel.Location = new Point(570, 95);
            lblNotesLabel.Name = "lblNotesLabel";
            lblNotesLabel.Size = new Size(101, 14);
            lblNotesLabel.TabIndex = 11;
            lblNotesLabel.Text = "Notes (Optional):";
            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.White;
            txtNotes.Font = new Font("Cambria", 9F);
            txtNotes.Location = new Point(570, 115);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(550, 65);
            txtNotes.TabIndex = 12;
            // 
            // lblTotalDisplay
            // 
            lblTotalDisplay.Font = new Font("Cambria", 14F, FontStyle.Bold);
            lblTotalDisplay.ForeColor = Color.Gold;
            lblTotalDisplay.Location = new Point(570, 190);
            lblTotalDisplay.Name = "lblTotalDisplay";
            lblTotalDisplay.Size = new Size(550, 30);
            lblTotalDisplay.TabIndex = 13;
            lblTotalDisplay.Text = "TOTAL: KES 0.00";
            lblTotalDisplay.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCartTitle
            // 
            lblCartTitle.AutoSize = true;
            lblCartTitle.Font = new Font("Cambria", 11F, FontStyle.Bold);
            lblCartTitle.ForeColor = Color.Gold;
            lblCartTitle.Location = new Point(15, 345);
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Size = new Size(121, 17);
            lblCartTitle.TabIndex = 14;
            lblCartTitle.Text = "SHOPPING CART";
            // 
            // pnlCart
            // 
            pnlCart.BackColor = Color.FromArgb(70, 70, 70);
            pnlCart.BorderStyle = BorderStyle.FixedSingle;
            pnlCart.Controls.Add(dgvCart);
            pnlCart.Location = new Point(15, 370);
            pnlCart.Name = "pnlCart";
            pnlCart.Size = new Size(1150, 300);
            pnlCart.TabIndex = 15;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToOrderColumns = true;
            dgvCart.BackgroundColor = Color.Gray;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.Columns.AddRange(new DataGridViewColumn[] { colProduct, colQty, colPrice, colTotal, colRemove });
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.GridColor = Color.DarkGray;
            dgvCart.Location = new Point(0, 0);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(1148, 298);
            dgvCart.TabIndex = 16;
            // 
            // colProduct
            // 
            colProduct.HeaderText = "Product Name";
            colProduct.Name = "colProduct";
            colProduct.Width = 400;
            // 
            // colQty
            // 
            colQty.HeaderText = "Qty";
            colQty.Name = "colQty";
            colQty.Width = 80;
            // 
            // colPrice
            // 
            colPrice.HeaderText = "Unit Price (KES)";
            colPrice.Name = "colPrice";
            colPrice.Width = 150;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Total (KES)";
            colTotal.Name = "colTotal";
            colTotal.Width = 150;
            // 
            // colRemove
            // 
            colRemove.HeaderText = "Remove";
            colRemove.Name = "colRemove";
            colRemove.Text = "Delete";
            colRemove.UseColumnTextForButtonValue = true;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(70, 70, 70);
            pnlButtons.BorderStyle = BorderStyle.FixedSingle;
            pnlButtons.Controls.Add(btnCompleteSale);
            pnlButtons.Controls.Add(btnClear);
            pnlButtons.Controls.Add(btnClose);
            pnlButtons.Controls.Add(lblItemCount);
            pnlButtons.Location = new Point(15, 680);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(1150, 80);
            pnlButtons.TabIndex = 17;
            // 
            // btnCompleteSale
            // 
            btnCompleteSale.BackColor = Color.FromArgb(0, 153, 0);
            btnCompleteSale.FlatStyle = FlatStyle.Popup;
            btnCompleteSale.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnCompleteSale.ForeColor = Color.White;
            btnCompleteSale.Location = new Point(20, 15);
            btnCompleteSale.Name = "btnCompleteSale";
            btnCompleteSale.Size = new Size(180, 50);
            btnCompleteSale.TabIndex = 18;
            btnCompleteSale.Text = "COMPLETE SALE";
            btnCompleteSale.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Orange;
            btnClear.FlatStyle = FlatStyle.Popup;
            btnClear.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(210, 15);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 50);
            btnClear.TabIndex = 19;
            btnClear.Text = "CLEAR CART";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(220, 53, 69);
            btnClose.FlatStyle = FlatStyle.Popup;
            btnClose.Font = new Font("Cambria", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(370, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 50);
            btnClose.TabIndex = 20;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblItemCount
            // 
            lblItemCount.Font = new Font("Cambria", 9F);
            lblItemCount.ForeColor = Color.LightGray;
            lblItemCount.Location = new Point(700, 20);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.Size = new Size(430, 25);
            lblItemCount.TabIndex = 21;
            lblItemCount.Text = "Items in Cart: 0";
            lblItemCount.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Sales
            // 
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1184, 749);
            Controls.Add(lblTitle);
            Controls.Add(pnlTop);
            Controls.Add(lblCartTitle);
            Controls.Add(pnlCart);
            Controls.Add(pnlButtons);
            Font = new Font("Cambria", 10F);
            Name = "Sales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New Sale";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            pnlCart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridViewTextBoxColumn colProduct;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewButtonColumn colRemove;
    }
}
