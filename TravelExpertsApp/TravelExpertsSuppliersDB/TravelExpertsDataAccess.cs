using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TravelExpertsSuppliersDB.Models;

namespace TravelExpertsSuppliersDB;

public record SupplierDTO(string SupplierId, string SupplierName, int numContacts); // Data Transfer Object to plug into Forms

public record SupplierContactDTO(string SupplierContactId, string SupConFirstName, string SupConLastName); // Data Transfer Object to plug into Forms

public class TravelExpertsDataAccess
{
    private TravelExpertsContext db = new(); // The Database

    public Supplier? FindSupplier(int supplierId)
    {
        try
        {
            return db.Suppliers.Find(supplierId);
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public List<SupplierDTO> GetAllSuppliers() =>
        db.Suppliers
            .OrderBy(p => p.SupplierId)
            .Select(p => new SupplierDTO(p.SupplierId.ToString()!, p.SupName!,
                p.SupplierContacts.Count()!))
            .ToList();


    public List<SupplierContactDTO> GetSupplierContacts(Supplier supplier) =>
        supplier.SupplierContacts
            .OrderBy(p => p.SupplierContactId)
            .Select(p => new SupplierContactDTO(p.SupplierContactId.ToString()!, p.SupConFirstName!,
                p.SupConLastName!))
            .ToList();

    public void AddSupplier(Supplier supplier)
    {
        try
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw CreateDataAccessException(ex);
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void UpdateSupplier(Supplier supplier) // Updates the passed supplier in the DB
    {
        try
        {
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var state = db.Entry(supplier).State;
            throw CreateDataAccessException(state);
        }
        catch (DbUpdateException ex)
        {
            throw CreateDataAccessException(ex);
        }

        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void RemoveSupplier(Supplier supplier) // deletes the passed supplier from the DB
    {
        try
        {
            db.Suppliers.Remove(supplier);
            db.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var state = db.Entry(supplier).State;
            throw CreateDataAccessException(state);
        }
        catch (DbUpdateException ex)
        {
            throw CreateDataAccessException(ex);
        }

        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void AddProduct(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
    }

    public void EditProduct(String newName,int ID)
    {
        var query = (from prod in db.Products where prod.ProductId == ID select prod).ToList();
        query[0].ProdName = newName;
        db.SaveChanges();
    }

    public void DeleteProduct(int ID)
    {
        var query = db.Products.Where(x => x.ProductId == ID).Select(x => x).ToArray();
        if (query.Length >= 1)
        {
            db.Products.Remove(query[0]);
            db.SaveChanges();
        }
    }

    private DataAccessException CreateDataAccessException( // Returns a DataAccessException based on the type passed
        EntityState state)
    {
        string msg = "";
        if (state == EntityState.Detached)
            msg = "Another user has deleted that record.";
        else
            msg = "Another user has updated that record.\n" +
            "The current database values will be displayed.";

        return new DataAccessException(msg, "Concurrency Error");
    }

    private DataAccessException CreateDataAccessException( // Returns a DataAccessException based on the type passed
        DbUpdateException ex)
    {
        var sqlException = (SqlException)ex.InnerException!;
        return CreateDataAccessException(sqlException);
    }

    private DataAccessException CreateDataAccessException(SqlException ex) // Returns a DataAccessException based on the type passed
    {
        string msg = "";
        foreach (SqlError error in ex.Errors)
        {
            msg += $"ERROR CODE {error.Number}: {error.Message}\n";
        }

        return new DataAccessException(msg, "Database Error");
    }
}
