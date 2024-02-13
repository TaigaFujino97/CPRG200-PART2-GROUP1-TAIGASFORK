using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsDB
{
    public static class CustomerManager
    {
        public static Customer Authenticate(TravelExpertsContext db, string email, string password)
        {
            var cust = db.Customers.SingleOrDefault(cst => cst.CustEmail == email
                                                    && cst.Password == password);
            return cust; //this will either be null or an object
        }

        public static void CreateCustomer(TravelExpertsContext db, Customer customer)
        {
                db.Customers.Add(customer);
                db.SaveChanges();
        }

        public static void UpdateCustomer(TravelExpertsContext db, int id, Customer updatedCustomer)
        {
            Customer? customer = db.Customers.Find(id);
            if (customer != null)
            {
                customer.CustFirstName = updatedCustomer.CustFirstName;
                customer.CustLastName = updatedCustomer.CustLastName;
                customer.CustEmail = updatedCustomer.CustEmail;
                customer.CustAddress = updatedCustomer.CustAddress;
                customer.CustCity = updatedCustomer.CustCity;
                customer.CustCountry = updatedCustomer.CustCountry;
                customer.CustPostal = updatedCustomer.CustPostal;
                customer.CustProv = updatedCustomer.CustProv;
                db.Customers.Update(customer);
                db.SaveChanges(); // save  changes to the database
            }
        }

        public static void UpdatePassword(TravelExpertsContext db, int? id, string newPassword)
        {
            Customer? customer = db.Customers.Find(id);
            if (customer != null)
            {
                customer.Password = newPassword;
                db.Customers.Update(customer);
                db.SaveChanges();
            }
        }
        public static bool EmailExists(TravelExpertsContext db, string email)
        {
                bool exists = db.Customers.Any(cst => cst.CustEmail.ToLower() == email.ToLower());
                return exists;
        }

        public static bool NewEmailExists(TravelExpertsContext db, int? id, string email)
        {
            bool exists = db.Customers.Any(cst => cst.CustomerId != id && cst.CustEmail.ToLower() == email.ToLower());
            return exists;

        }
        public static Customer GetCustomerData(TravelExpertsContext db, int? id)
        {
            var cust = db.Customers.SingleOrDefault(cst => cst.CustomerId == id);
            return cust;
        }
    }
}
