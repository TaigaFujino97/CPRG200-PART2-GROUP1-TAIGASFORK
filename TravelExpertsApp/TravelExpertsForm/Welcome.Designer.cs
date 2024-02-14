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
            btnPackages = new Button();
            btnSuppliers = new Button();
            btnPackage = new Button();
            SuspendLayout();
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(91, 292);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(144, 70);
            btnPackages.TabIndex = 0;
            btnPackages.Text = "&Products";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnProds_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(527, 292);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(180, 70);
            btnSuppliers.TabIndex = 1;
            btnSuppliers.Text = "&Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnPackage
            // 
            btnPackage.Location = new Point(294, 292);
            btnPackage.Name = "btnPackage";
            btnPackage.Size = new Size(170, 70);
            btnPackage.TabIndex = 2;
            btnPackage.Text = "P&ackages";
            btnPackage.UseVisualStyleBackColor = true;
            btnPackage.Click += btnPackage_Click;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPackage);
            Controls.Add(btnSuppliers);
            Controls.Add(btnPackages);
            Name = "Welcome";
            Text = "Welcome";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPackages;
        private Button btnSuppliers;
        private Button btnPackage;
    }
}