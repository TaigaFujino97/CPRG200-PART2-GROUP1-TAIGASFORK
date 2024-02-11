using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsSuppliersDB;
using TravelExpertsSuppliersDB.Models;

namespace Workshop4 //Mikkel Giesbrecht 2024/01
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            TravelExpertsContext db = new TravelExpertsContext();
            var query = from product in db.Products select product;
            cmbProductID.Items.Clear();
            foreach (var item in query)
            {
                cmbProductID.Items.Add(item.ProductId);
            }
            cmbProductID.SelectedIndex = 0;
        }

        public void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            var query = db.Products.Where(x => x.ProductId == Convert.ToInt32(cmbProductID.Text)).Select(x => x).ToArray();
            if (query.Length >= 1)
            {
                txtProductName.Text = query[0].ProdName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditProducts frm = new AddEditProducts("Add Product", cmbProductID.Text, txtProductName.Text);
            this.Hide();
            frm.FormClosed += new FormClosedEventHandler(CloseForm);
            frm.ShowDialog();
        }

        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            this.Show();
            TravelExpertsContext db = new TravelExpertsContext();
            var query = from product in db.Products select product;
            cmbProductID.Items.Clear();
            foreach (var item in query)
            {
                cmbProductID.Items.Add(item.ProductId);
            }
            cmbProductID.SelectedIndex = 0;
        }

        private void RefreshList()
        {
            TravelExpertsContext db = new TravelExpertsContext();
            var query = from product in db.Products select product;
            cmbProductID.Items.Clear();
            foreach (var item in query)
            {
                cmbProductID.Items.Add(item.ProductId);
            }
            cmbProductID.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddEditProducts frm = new AddEditProducts("Edit Product", cmbProductID.Text, txtProductName.Text);
            this.Hide();
            frm.FormClosed += new FormClosedEventHandler(CloseForm);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete "+txtProductName.Text+"?","Delete Product.",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TravelExpertsDataAccess.DeleteProduct(Convert.ToInt32(cmbProductID.Text));
                RefreshList();
            }
        }
    }
}