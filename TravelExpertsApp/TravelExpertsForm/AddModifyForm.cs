using TravelExpertsSuppliersDB.Models;
using TravelExpertsSuppliersDB;

namespace TravelExpertsForm;
/// <summary>
/// A form to add a new product or modify an existing product.
/// </summary>
/// <author>
/// Michael Chessall
/// </author>
/// <date>
/// 1/21/2024
/// </date>
public partial class AddModifyForm : Form
{
    private SupplierContact selectedSupplierContact = null!; // Which product is currently being modified/deleted
    private TravelExpertsDataAccess dbAccess = new(); // A Class for accessing dbAccess from TechSupport db
    public AddModifyForm()
    {
        InitializeComponent();
    }

    public Supplier Supplier { get; set; } = null!; // used to populate the initial data and to pass back to the DB save changes

    private void frmAddModify_Load(object sender, EventArgs e)
    {
        if (Supplier == null)
        {
            Text = "Add Supplier";
            txtSupplierCode.ReadOnly = false;  // allow entry of new product code

            // initialize form level Supplier property
            Supplier = new();
            txtSupplierCode.Text = Supplier.SupplierId.ToString();
        }
        else
        {
            Text = "Modify Supplier";
            txtSupplierCode.ReadOnly = true;   // can't change existing product code
            DisplaySupplier();
        }
    }

    private void DisplaySupplier()
    {
        // display the product information
        txtSupplierCode.Text = Supplier.SupplierId.ToString();
        txtName.Text = Supplier.SupName;
        txtName.Focus();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        if (IsValidData()) // check the data
        {
            LoadSupplierData(); // load the data into the stored product object
            DialogResult = DialogResult.OK;
        }
    }

    private bool IsValidData() // check the data for validity
    {
        bool success = true;
        string errorMessage = "";

        errorMessage += Validator.IsPresent(txtName.Text, "Name");
        errorMessage += Validator.IsWithinLength(txtName.Text, "Name", 1, 50); //  varchar(50)

        if (!string.IsNullOrEmpty(errorMessage))
        {
            success = false;
            MessageBox.Show(errorMessage, "Entry Error");
        }
        return success;
    }

    private void LoadSupplierData() // Load the product data into the product
    {
        Supplier.SupName = txtName.Text;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }

}
