namespace TravelExpertsForm
{
    partial class SuppliersForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSuppliers = new DataGridView();
            SupplierId = new DataGridViewTextBoxColumn();
            SupplierName = new DataGridViewTextBoxColumn();
            ContactsNumber = new DataGridViewTextBoxColumn();
            btnCancel = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.Columns.AddRange(new DataGridViewColumn[] { SupplierId, SupplierName, ContactsNumber });
            dgvSuppliers.Location = new Point(12, 31);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.Size = new Size(630, 165);
            dgvSuppliers.TabIndex = 0;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // SupplierId
            // 
            SupplierId.HeaderText = "supplier ID";
            SupplierId.Name = "SupplierId";
            SupplierId.Width = 60;
            // 
            // SupplierName
            // 
            SupplierName.HeaderText = "Name";
            SupplierName.Name = "SupplierName";
            SupplierName.Width = 250;
            // 
            // ContactsNumber
            // 
            ContactsNumber.HeaderText = "Number of Contacts";
            ContactsNumber.Name = "ContactsNumber";
            ContactsNumber.Width = 60;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(136, 212);
            btnCancel.Margin = new Padding(2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 40);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 212);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(108, 40);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "New supplier";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 263);
            Controls.Add(btnAdd);
            Controls.Add(btnCancel);
            Controls.Add(dgvSuppliers);
            Name = "SuppliersForm";
            Text = "Suppliers";
            Load += SuppliersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSuppliers;
        private DataGridViewTextBoxColumn SupplierId;
        private DataGridViewTextBoxColumn SupplierName;
        private DataGridViewTextBoxColumn ContactsNumber;
        private Button btnCancel;
        private Button btnAdd;
    }
}
