using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Workshop4;
using TravelPackageGUI;
using ThreadedWorkshop4;

namespace TravelExpertsForm
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            SuppliersForm SuppliersForm = new SuppliersForm();
            SuppliersForm.Show();
        }

        private void btnProds_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            TravelPackageManager travelPackageManager = new TravelPackageManager();
            travelPackageManager.Show();
        }
    }
}
