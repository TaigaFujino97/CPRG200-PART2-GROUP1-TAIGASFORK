namespace Workshop4
{
    partial class AddEditProducts
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
            txtProductID = new TextBox();
            txtProductName = new TextBox();
            lblProductName = new Label();
            btnOk = new Button();
            btnCancel = new Button();
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
            // txtProductID
            // 
            txtProductID.Enabled = false;
            txtProductID.Location = new Point(100, 6);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(206, 27);
            txtProductID.TabIndex = 1;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(125, 39);
            txtProductName.MaxLength = 50;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(181, 27);
            txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(12, 42);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(107, 20);
            lblProductName.TabIndex = 2;
            lblProductName.Text = "Product Name:";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(64, 74);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(164, 74);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddEditProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 115);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtProductName);
            Controls.Add(lblProductName);
            Controls.Add(txtProductID);
            Controls.Add(lblProductID);
            Name = "AddEditProducts";
            Text = "Add Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductID;
        private TextBox txtProductID;
        private TextBox txtProductName;
        private Label lblProductName;
        private Button btnOk;
        private Button btnCancel;
    }
}