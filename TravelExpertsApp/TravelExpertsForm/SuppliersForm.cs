using TravelExpertsSuppliersDB;
using TravelExpertsSuppliersDB.Models;

namespace TravelExpertsForm
{
    public partial class SuppliersForm : Form
    {
        private Supplier selectedSupplier = null!; // Which product is currently being modified/deleted
        private TravelExpertsDataAccess dbAccess = new(); // A Class for accessing dbAccess from TechSupport db
        public SuppliersForm()
        {
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }

        private void DisplaySuppliers()  // Refreshes the Suppliers
        {
            dgvSuppliers.Columns.Clear(); // Clear any existing data.
            dgvSuppliers.DataSource = dbAccess.GetAllSuppliers();  // Pulls a formatted list of data from the DB

            // add column for modify button
            DataGridViewButtonColumn modifyColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Modify"
            };
            dgvSuppliers.Columns.Add(modifyColumn);

            // add column for delete button
            DataGridViewButtonColumn deleteColumn = new()
            {
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                Text = "Remove"
            };
            dgvSuppliers.Columns.Add(deleteColumn);

            // format the column header
            dgvSuppliers.EnableHeadersVisualStyles = false;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvSuppliers.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvSuppliers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // format the odd numbered rows
            dgvSuppliers.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleGoldenrod;


        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // index values for Modify and Delete button columns
            const int ModifyIndex = 3;
            const int DeleteIndex = 4;

            if (e.RowIndex > -1)  // make sure header row wasn't clicked
            {
                if (e.ColumnIndex == ModifyIndex || e.ColumnIndex == DeleteIndex)
                {
                    DataGridViewCell cell = dgvSuppliers.Rows[e.RowIndex].Cells[0];
                    int supplierId = Int32.Parse(cell.Value?.ToString());
                    selectedSupplier = dbAccess.FindSupplier(supplierId);
                }

                if (selectedSupplier != null)
                {
                    if (e.ColumnIndex == ModifyIndex)
                    {
                        ModifySupplier();
                    }
                    else if (e.ColumnIndex == DeleteIndex)
                    {
                        DeleteSupplier();
                    }
                }
            }
        }

        private void DeleteSupplier()
        {
            DialogResult result =
                MessageBox.Show($"Delete {selectedSupplier.SupName}?",
                "Confirm Delete", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    dbAccess.RemoveSupplier(selectedSupplier);
                    DisplaySuppliers();
                }
                catch (DataAccessException ex)
                {
                    HandleDataAccessError(ex);
                }
            }
        }

        private void ModifySupplier()
        {
            AddModifyForm addModifyForm = new()
            {
                Supplier = selectedSupplier
            };
            DialogResult result = addModifyForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    selectedSupplier = addModifyForm.Supplier;
                    dbAccess.UpdateSupplier(selectedSupplier);
                    DisplaySuppliers();
                }

                catch (DataAccessException ex)
                {
                    HandleDataAccessError(ex);
                }
            }
        }

        private void HandleDataAccessError(DataAccessException ex)
        {
            // if concurrency conflict, re-display products
            if (ex.IsConcurrencyError)
            {
                DisplaySuppliers();
            }

            // display error message in dialog with error type as title
            MessageBox.Show(ex.Message, ex.ErrorType);
        }

    }
}
