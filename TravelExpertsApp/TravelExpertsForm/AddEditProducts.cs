using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsSuppliersDB;
using TravelExpertsSuppliersDB.Models;

namespace Workshop4 //Mikkel Giesbrecht 2024/01
{
    public partial class AddEditProducts : Form
    {
        public AddEditProducts(string title, string prodID, string prodName)
        {
            InitializeComponent();
            this.Text = title;
            if (title == "Edit Product")
            {
                txtProductID.Text = prodID;
            }
            else
            {
                TravelExpertsContext db = new TravelExpertsContext();
                var query = db.Products.Max(x => x.ProductId);
                txtProductID.Text = (query + 1).ToString();
            }
            txtProductName.Text = prodName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.Text == "Add Product")
            {//Adding product
                if (txtProductName.Text != "")
                {
                    TravelExpertsDataAccess db = new TravelExpertsDataAccess();
                    Product item = new Product();
                    item.ProdName = txtProductName.Text;
                    db.AddProduct(item);
                    this.Close();
                }
            } else
            {//Editing product
                if (txtProductName.Text != "")
                {
                    TravelExpertsDataAccess db = new TravelExpertsDataAccess();
                    db.EditProduct(txtProductName.Text, Convert.ToInt32(txtProductID));
                    this.Close();
                }
            }
        }
    }
}
