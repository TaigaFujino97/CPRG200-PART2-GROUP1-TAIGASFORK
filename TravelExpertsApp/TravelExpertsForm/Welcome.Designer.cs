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
            pictureBox1 = new PictureBox();
            btnAgents = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(3, 3);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(227, 79);
            btnPackages.TabIndex = 0;
            btnPackages.Text = "&Products";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnProds_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(469, 3);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(227, 79);
            btnSuppliers.TabIndex = 1;
            btnSuppliers.Text = "&Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnPackage
            // 
            btnPackage.Location = new Point(236, 3);
            btnPackage.Name = "btnPackage";
            btnPackage.Size = new Size(227, 79);
            btnPackage.TabIndex = 2;
            btnPackage.Text = "P&ackages";
            btnPackage.UseVisualStyleBackColor = true;
            btnPackage.Click += btnPackage_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(935, 355);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnAgents
            // 
            btnAgents.Location = new Point(702, 3);
            btnAgents.Name = "btnAgents";
            btnAgents.Size = new Size(230, 79);
            btnAgents.TabIndex = 4;
            btnAgents.Text = "&Agents";
            btnAgents.UseVisualStyleBackColor = true;
            btnAgents.Click += btnAgents_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnPackages, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAgents, 3, 0);
            tableLayoutPanel1.Controls.Add(btnPackage, 1, 0);
            tableLayoutPanel1.Controls.Add(btnSuppliers, 2, 0);
            tableLayoutPanel1.Location = new Point(3, 364);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(935, 85);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel2.Location = new Point(12, 12);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(941, 452);
            tableLayoutPanel2.TabIndex = 6;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RoyalBlue;
            ClientSize = new Size(965, 476);
            Controls.Add(tableLayoutPanel2);
            MaximumSize = new Size(983, 523);
            MinimumSize = new Size(983, 523);
            Name = "Welcome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnPackages;
        private Button btnSuppliers;
        private Button btnPackage;
        private PictureBox pictureBox1;
        private Button btnAgents;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
    }
}