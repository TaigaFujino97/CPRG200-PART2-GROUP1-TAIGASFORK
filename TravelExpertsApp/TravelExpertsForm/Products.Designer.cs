namespace Workshop4
{
    partial class Products
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
            lblProductID = new Label();
            cmbProductID = new ComboBox();
            lblProductName = new Label();
            txtProductName = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnReturn = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblProductID
            // 
            lblProductID.AutoSize = true;
            lblProductID.Location = new Point(12, 9);
            lblProductID.Name = "lblProductID";
            lblProductID.Size = new Size(82, 20);
            lblProductID.TabIndex = 0;
            lblProductID.Text = "Product ID:";
            // 
            // cmbProductID
            // 
            cmbProductID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductID.FormattingEnabled = true;
            cmbProductID.Location = new Point(100, 6);
            cmbProductID.Name = "cmbProductID";
            cmbProductID.Size = new Size(206, 28);
            cmbProductID.TabIndex = 1;
            cmbProductID.SelectedIndexChanged += cmbProductID_SelectedIndexChanged;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(12, 44);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(107, 20);
            lblProductName.TabIndex = 3;
            lblProductName.Text = "Product Name:";
            // 
            // txtProductName
            // 
            txtProductName.Enabled = false;
            txtProductName.Location = new Point(125, 41);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(181, 27);
            txtProductName.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 79);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(112, 79);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 29);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(212, 114);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 7;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(212, 79);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 154);
            Controls.Add(btnDelete);
            Controls.Add(btnReturn);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtProductName);
            Controls.Add(lblProductName);
            Controls.Add(cmbProductID);
            Controls.Add(lblProductID);
            Name = "Products";
            Text = "Manage Products";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductID;
        private ComboBox cmbProductID;
        private Label lblProductName;
        private TextBox txtProductName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnReturn;
        private Button btnDelete;
    }
}