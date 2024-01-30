using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security;
using TravelPackageData;
using TravelPackageGUI;

namespace ThreadedWorkshop4
{
    public partial class TravelPackageManager : Form
    {
        private Package? selectedPackage = null;
        public TravelPackageManager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                cboPackageName.DataSource = db.Packages.ToList();
                cboPackageName.DisplayMember = "PkgName";
                cboPackageName.ValueMember = "PackageID";

                if (selectedPackage != null)
                {
                    DisplayProduct();
                }

            }
        }
        private void cboProductID_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboPackageName.SelectedValue != null)
            {
                // convert the selected Product value to a string
                string PackCodeString = cboPackageName.SelectedValue.ToString()!;

                if (int.TryParse(PackCodeString, out int PackCode))
                {
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())
                        {
                            // check if customer exists

                            selectedPackage = db.Packages.Find(PackCode); //Find the matching product key from the database
                            if (selectedPackage != null)
                            {
                                DisplayProduct();// if the product code exists, displays the product
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error while retrieving customer data: " + ex.Message,
                            "Database Error");
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Unanticipated error: " + ex.Message,
                            ex.GetType().ToString());
                    }
                }
            }
        }

        private void DisplayProduct()
        {

            DateTime? startDateNullable = selectedPackage!.PkgStartDate;
            DateTime? endDateNullable = selectedPackage!.PkgEndDate;
            decimal? commissionNullable = selectedPackage!.PkgAgencyCommission;
            if (selectedPackage != null)
            {
                cboPackageName.SelectedItem = selectedPackage.PackageId;
                cboPackageName.Text = selectedPackage.PackageId.ToString();
                txtID.Text = Convert.ToString(selectedPackage.PackageId);
                if (startDateNullable.HasValue)
                {
                    txtStartDate.Text = startDateNullable.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    // Handle the case when startDateNullable is null
                    txtStartDate.Text = "N/A";  // Provide a default value or handle it as needed
                }
                if (endDateNullable.HasValue)
                {
                    txtEndDate.Text = endDateNullable.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    txtEndDate.Text = "N/A";
                }
                txtDesc.Text = selectedPackage.PkgDesc;
                txtBasePrice.Text = selectedPackage.PkgBasePrice.ToString("c");
                if (commissionNullable.HasValue)
                {
                    txtCommission.Text = commissionNullable.Value.ToString("c");
                }
                else
                {
                    txtCommission.Text = "N/A";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // display second form to collect data
            frmAddModifyPackage secondForm = new frmAddModifyPackage();

            secondForm.isAdd = true; // it is Add operation
            secondForm.package = null; // open second form with empty text boxes

            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // second form collected data
            {
                // make selected customer on this form the one from the other form
                selectedPackage = secondForm.package;

                // add it to the Customers table
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        if (selectedPackage != null)
                        {
                            db.Packages.Add(selectedPackage); // add new product to database
                            db.SaveChanges(); // saves the changes
                            List<Package> packages = db.Packages.ToList();
                            cboPackageName.DataSource = packages;
                            cboPackageName.DisplayMember = "PckName";
                            cboPackageName.ValueMember = "PackageID";
                            //Since the PackageID is auto genenrated it will always be the last index.
                            cboPackageName.SelectedIndex = packages.Count() - 1;
                            DisplayProduct(); // displays the added product information
                        }
                    }
                }
                catch (DbUpdateException ex)
                {
                    string msg = "";
                    var sqlException =
                        (SqlException)ex.InnerException!;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        msg += $"ERROR CODE {error.Number}: {error.Message}\\n";
                    }
                    MessageBox.Show(msg, "Database Error");
                    Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error while adding customer: " + ex.Message,
                        "Database Error");
                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unanticipated error: " + ex.Message,
                        ex.GetType().ToString());
                    Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // display second form with current data
            // and collect new data values
            frmAddModifyPackage secondForm = new frmAddModifyPackage();
            secondForm.isAdd = false; // it is Modify operation
            secondForm.package = selectedPackage; // pass selected customer to the second form

            DialogResult result = secondForm.ShowDialog();
            if (result == DialogResult.OK) // second form collected new data
            {
                // make selected customer on this form the one from the other form
                selectedPackage = secondForm.package;
                // update the selected customer data on the Customers table
                try
                {
                    using (TravelExpertsContext db = new TravelExpertsContext())
                    {
                        if (selectedPackage != null)
                        {
                            db.Packages.Update(selectedPackage); // updates the selected product on the database
                            db.SaveChanges(); // saves the changes to the database
                            DisplayProduct(); // displays the modified product
                        }
                    }
                }
                catch (DbUpdateException ex)
                {
                    string msg = "";
                    var sqlException =
                        (SqlException)ex.InnerException!;
                    foreach (SqlError error in sqlException.Errors)
                    {
                        msg += $"ERROR CODE {error.Number}: {error.Message}\\n";
                    }
                    MessageBox.Show(msg, "Database Error");
                    Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error while modifying customer: " + ex.Message,
                        "Database Error");
                    Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unanticipated error: " + ex.Message,
                        ex.GetType().ToString());
                    Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // remove the selected customer data on the Customers table
            if (selectedPackage != null)
            {
                // get the user's confirmation
                DialogResult answer = MessageBox.Show(
                    $"Are you sure you want to delete {selectedPackage.PkgName}?",
                    "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    );
                if (DialogResult.Yes == answer)
                {
                    try
                    {
                        using (TravelExpertsContext db = new TravelExpertsContext())
                        {
                            db.Packages.Remove(selectedPackage); // removes the selected product from the database
                            db.SaveChanges(); // saves the changes to the database
                            cboPackageName.DataSource = db.Packages.ToList(); // updates the product list after product has been removed
                            // redisplays the updated product codes to the combo box
                            cboPackageName.DisplayMember = "PckName";
                            cboPackageName.ValueMember = "PackageID";
                            selectedPackage = null;
                            ClearControls(); // clears the text boxes
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        string msg = "";
                        var sqlException =
                            (SqlException)ex.InnerException!;
                        foreach (SqlError error in sqlException.Errors)
                        {
                            msg += $"ERROR CODE {error.Number}: {error.Message}\\n";
                        }
                        MessageBox.Show(msg, "Database Error");
                        Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error while deleting customer: " + ex.Message,
                            "Database Error");
                        Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Unanticipated error: " + ex.Message,
                            ex.GetType().ToString());
                        Close();
                    }
                }
            }
        }

        private void ClearControls()
        {
            txtID.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtCommission.Text = string.Empty;
            txtBasePrice.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
