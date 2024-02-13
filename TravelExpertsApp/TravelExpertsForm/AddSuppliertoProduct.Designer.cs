namespace TravelExpertsForm
{
    partial class AddSuppliertoProduct
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
            components = new System.ComponentModel.Container();
            lblProduct = new Label();
            lblSupplier = new Label();
            btnAdd = new Button();
            btnCancel = new Button();
            cmbProduct = new ComboBox();
            cmbSupplier = new ComboBox();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            productsSupplierBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(12, 9);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(63, 20);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Product:";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(12, 42);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(67, 20);
            lblSupplier.TabIndex = 2;
            lblSupplier.Text = "Supplier:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 75);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(212, 75);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbProduct
            // 
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(81, 6);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(225, 28);
            cmbProduct.TabIndex = 6;
            // 
            // cmbSupplier
            // 
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(81, 39);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(225, 28);
            cmbSupplier.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(112, 75);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(590, 358);
            dataGridView1.TabIndex = 9;
            // 
            // productsSupplierBindingSource
            // 
            productsSupplierBindingSource.DataSource = typeof(TravelExpertsSuppliersDB.Models.ProductsSupplier);
            // 
            // AddSuppliertoProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 480);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(cmbSupplier);
            Controls.Add(cmbProduct);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(lblSupplier);
            Controls.Add(lblProduct);
            Name = "AddSuppliertoProduct";
            Text = "AddSuppliertoProduct";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productsSupplierBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProduct;
        private Label lblSupplier;
        private Button btnAdd;
        private Button btnCancel;
        private ComboBox cmbProduct;
        private ComboBox cmbSupplier;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private BindingSource productsSupplierBindingSource;
    }
}