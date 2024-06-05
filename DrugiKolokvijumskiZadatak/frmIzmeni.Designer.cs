namespace DrugiKolokvijumskiZadatak
{
    partial class frmIzmeni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbShipper = new System.Windows.Forms.ComboBox();
            this.lblShipper = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Location = new System.Drawing.Point(632, 29);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(109, 40);
            this.btnUpdateOrder.TabIndex = 60;
            this.btnUpdateOrder.Text = "Update Order";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 193);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(732, 245);
            this.dataGrid.TabIndex = 59;
            this.dataGrid.SelectionChanged += new System.EventHandler(this.dataGrid_SelectionChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(203, 121);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(38, 16);
            this.lblPrice.TabIndex = 58;
            this.lblPrice.Text = "Price";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(482, 141);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(121, 22);
            this.txtDiscount.TabIndex = 57;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(343, 141);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(121, 22);
            this.txtQuantity.TabIndex = 56;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(206, 141);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(121, 22);
            this.txtPrice.TabIndex = 55;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.Location = new System.Drawing.Point(632, 131);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(109, 39);
            this.btnUpdateItem.TabIndex = 54;
            this.btnUpdateItem.Text = "Update Item";
            this.btnUpdateItem.UseVisualStyleBackColor = true;
            this.btnUpdateItem.Click += new System.EventHandler(this.btnUpdateItem_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(479, 122);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(59, 16);
            this.lbl.TabIndex = 53;
            this.lbl.Text = "Discount";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(340, 122);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(55, 16);
            this.lblQuantity.TabIndex = 52;
            this.lblQuantity.Text = "Quantity";
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(22, 141);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(178, 24);
            this.cmbProduct.TabIndex = 51;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(19, 122);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(53, 16);
            this.lblProduct.TabIndex = 50;
            this.lblProduct.Text = "Product";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(448, 47);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 16);
            this.lblDate.TabIndex = 49;
            this.lblDate.Text = "DATE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Date";
            // 
            // cmbShipper
            // 
            this.cmbShipper.FormattingEnabled = true;
            this.cmbShipper.Location = new System.Drawing.Point(297, 38);
            this.cmbShipper.Name = "cmbShipper";
            this.cmbShipper.Size = new System.Drawing.Size(121, 24);
            this.cmbShipper.TabIndex = 47;
            this.cmbShipper.SelectedIndexChanged += new System.EventHandler(this.cmbShipper_SelectedIndexChanged);
            // 
            // lblShipper
            // 
            this.lblShipper.AutoSize = true;
            this.lblShipper.Location = new System.Drawing.Point(294, 19);
            this.lblShipper.Name = "lblShipper";
            this.lblShipper.Size = new System.Drawing.Size(54, 16);
            this.lblShipper.TabIndex = 46;
            this.lblShipper.Text = "Shipper";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(160, 38);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(121, 24);
            this.cmbCustomer.TabIndex = 45;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(157, 19);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(64, 16);
            this.lblCustomer.TabIndex = 44;
            this.lblCustomer.Text = "Customer";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(22, 39);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(121, 24);
            this.cmbEmployee.TabIndex = 43;
            this.cmbEmployee.SelectedIndexChanged += new System.EventHandler(this.cmbEmployee_SelectedIndexChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(19, 20);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(69, 16);
            this.lblEmployee.TabIndex = 42;
            this.lblEmployee.Text = "Employee";
            // 
            // frmIzmeni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 450);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnUpdateItem);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbShipper);
            this.Controls.Add(this.lblShipper);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblEmployee);
            this.Name = "frmIzmeni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIzmeni";
            this.Load += new System.EventHandler(this.frmIzmeni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbShipper;
        private System.Windows.Forms.Label lblShipper;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblEmployee;
    }
}