namespace TravelExpertsForm;

partial class AddModifyForm
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
        label2 = new Label();
        txtName = new TextBox();
        label1 = new Label();
        txtSupplierCode = new TextBox();
        btnCancel = new Button();
        btnAccept = new Button();
        dataGridView1 = new DataGridView();
        SupplierContactId = new DataGridViewTextBoxColumn();
        SupConFirstName = new DataGridViewTextBoxColumn();
        SupConLastName = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(11, 269);
        label2.Margin = new Padding(2, 0, 2, 0);
        label2.Name = "label2";
        label2.Size = new Size(42, 15);
        label2.TabIndex = 12;
        label2.Text = "Name:";
        // 
        // txtName
        // 
        txtName.Location = new Point(103, 267);
        txtName.Margin = new Padding(2);
        txtName.Name = "txtName";
        txtName.Size = new Size(140, 23);
        txtName.TabIndex = 13;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(11, 239);
        label1.Margin = new Padding(2, 0, 2, 0);
        label1.Name = "label1";
        label1.Size = new Size(67, 15);
        label1.TabIndex = 9;
        label1.Text = "Supplier ID:";
        // 
        // txtSupplierCode
        // 
        txtSupplierCode.Location = new Point(103, 237);
        txtSupplierCode.Margin = new Padding(2);
        txtSupplierCode.Name = "txtSupplierCode";
        txtSupplierCode.ReadOnly = true;
        txtSupplierCode.Size = new Size(140, 23);
        txtSupplierCode.TabIndex = 10;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(112, 299);
        btnCancel.Margin = new Padding(2);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 24);
        btnCancel.TabIndex = 19;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnAccept
        // 
        btnAccept.Location = new Point(11, 299);
        btnAccept.Margin = new Padding(2);
        btnAccept.Name = "btnAccept";
        btnAccept.Size = new Size(90, 24);
        btnAccept.TabIndex = 18;
        btnAccept.Text = "Accept";
        btnAccept.UseVisualStyleBackColor = true;
        btnAccept.Click += btnAccept_Click;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { SupplierContactId, SupConFirstName, SupConLastName });
        dataGridView1.Location = new Point(12, 12);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new Size(452, 161);
        dataGridView1.TabIndex = 20;
        // 
        // SupplierContactId
        // 
        SupplierContactId.HeaderText = "Contact ID";
        SupplierContactId.Name = "SupplierContactId";
        // 
        // SupConFirstName
        // 
        SupConFirstName.HeaderText = "First  Name";
        SupConFirstName.Name = "SupConFirstName";
        // 
        // SupConLastName
        // 
        SupConLastName.HeaderText = "Last Name";
        SupConLastName.Name = "SupConLastName";
        // 
        // AddModifyForm
        // 
        AcceptButton = btnAccept;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(476, 334);
        ControlBox = false;
        Controls.Add(dataGridView1);
        Controls.Add(btnCancel);
        Controls.Add(btnAccept);
        Controls.Add(label2);
        Controls.Add(txtName);
        Controls.Add(label1);
        Controls.Add(txtSupplierCode);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(2);
        MaximizeBox = false;
        Name = "AddModifyForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Add / Modify";
        Load += frmAddModify_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Label label2;
    private TextBox txtName;
    private Label label1;
    private TextBox txtSupplierCode;
    private Button btnCancel;
    private Button btnAccept;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn SupplierContactId;
    private DataGridViewTextBoxColumn SupConFirstName;
    private DataGridViewTextBoxColumn SupConLastName;
}