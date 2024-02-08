namespace TravelExpertsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            //make this connect to the supplier form
            SupplierForm supplierForm = new SupplierForm();
            SupplierForm.Show();

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            SupplierForm supplierForm = new SupplierForm();
            SupplierForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SupplierForm prodSup = new SupplierForm();
            SupplierForm.Show();
        }
    }
}
