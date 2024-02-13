using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsForm;
using TravelExpertsSuppliersDB;
using TravelExpertsSuppliersDB.Models;

namespace TravelExpertsForm
{
    public partial class AddSuppliertoProduct : Form
    {
        public AddSuppliertoProduct()
        {
            InitializeComponent();
            TravelExpertsContext db = new TravelExpertsContext();
            var query = from product in db.Products select product;
            cmbProduct.Items.Clear();
            foreach (var item in query)
            {
                cmbProduct.Items.Add(item.ProdName);
            }
            cmbProduct.SelectedIndex = 0;
            var query2 = from supplier in db.Suppliers select supplier;
            cmbSupplier.Items.Clear();
            foreach (var item in query2)
            {
                cmbSupplier.Items.Add(item.SupName);
            }
            cmbSupplier.SelectedIndex = 0;
            dataGridView1.DataSource = db.ProductsSuppliers.Select(x => new {x.ProductSupplierId,x.Product.ProdName,x.Supplier.SupName}).ToList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbProduct.Text != "" && cmbSupplier.Text != "")
            {
                ProductsSupplier item = new ProductsSupplier();
                item.ProductId = TravelExpertsDataAccess.GetProductIdFromName(cmbProduct.Text);
                item.SupplierId = TravelExpertsDataAccess.GetSupplierIdFromName(cmbSupplier.Text);
                TravelExpertsDataAccess.AddProductsSupplier(item);
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbProduct.Text != "" && cmbSupplier.Text != "")
            {
                TravelExpertsDataAccess.DeleteProductsSupplier(TravelExpertsDataAccess.GetProductIdFromName(cmbProduct.Text), TravelExpertsDataAccess.GetSupplierIdFromName(cmbSupplier.Text));
                this.Close();
            }
        }
    }
}