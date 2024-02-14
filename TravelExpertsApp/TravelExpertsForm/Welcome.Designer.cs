namespace TravelExpertsForm
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            btnPackages = new Button();
            btnSuppliers = new Button();
            btnPackage = new Button();
            btnAgents = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnPackages
            // 
            btnPackages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPackages.Location = new Point(3, 3);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(215, 86);
            btnPackages.TabIndex = 0;
            btnPackages.Text = "&Products";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnProds_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSuppliers.Location = new Point(224, 95);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(216, 86);
            btnSuppliers.TabIndex = 1;
            btnSuppliers.Text = "&Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnPackage
            // 
            btnPackage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPackage.Location = new Point(3, 95);
            btnPackage.Name = "btnPackage";
            btnPackage.Size = new Size(215, 86);
            btnPackage.TabIndex = 2;
            btnPackage.Text = "P&ackages";
            btnPackage.UseVisualStyleBackColor = true;
            btnPackage.Click += btnPackage_Click;
            // 
            // btnAgents
            // 
            btnAgents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAgents.Location = new Point(224, 3);
            btnAgents.Name = "btnAgents";
            btnAgents.Size = new Size(216, 86);
            btnAgents.TabIndex = 3;
            btnAgents.Text = "&Agents";
            btnAgents.UseVisualStyleBackColor = true;
            btnAgents.Click += btnAgents_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnPackages, 0, 0);
            tableLayoutPanel1.Controls.Add(btnPackage, 0, 1);
            tableLayoutPanel1.Controls.Add(btnAgents, 1, 0);
            tableLayoutPanel1.Controls.Add(btnSuppliers, 1, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(443, 184);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 208);
            Controls.Add(tableLayoutPanel1);
            Name = "Welcome";
            Text = "Welcome";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnPackages;
        private Button btnSuppliers;
        private Button btnPackage;
        private Button btnAgents;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
    }
}