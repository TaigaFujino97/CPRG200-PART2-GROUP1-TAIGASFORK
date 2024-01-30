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
            SupplierCode = new DataGridViewTextBoxColumn();
            SupplierName = new DataGridViewTextBoxColumn();
            ContactsNumber = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Columns.AddRange(new DataGridViewColumn[] { SupplierCode, SupplierName, ContactsNumber });
            dgvSuppliers.Location = new Point(12, 31);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.Size = new Size(630, 165);
            dgvSuppliers.TabIndex = 0;
            dgvSuppliers.CellClick += dgvSuppliers_CellClick;
            // 
            // SupplierCode
            // 
            SupplierCode.HeaderText = "Supplier ID";
            SupplierCode.Name = "SupplierCode";
            SupplierCode.Width = 60;
            // 
            // SupplierName
            // 
            SupplierName.HeaderText = "Name";
            SupplierName.Name = "SupplierName";
            SupplierName.Width = 150;
            // 
            // ContactsNumber
            // 
            ContactsNumber.HeaderText = "Number of Contacts";
            ContactsNumber.Name = "ContactsNumber";
            ContactsNumber.Width = 60;
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 317);
            Controls.Add(dgvSuppliers);
            Name = "SuppliersForm";
            Text = "Suppliers";
            Load += SuppliersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSuppliers;
        private DataGridViewTextBoxColumn SupplierCode;
        private DataGridViewTextBoxColumn SupplierName;
        private DataGridViewTextBoxColumn ContactsNumber;
    }
}
