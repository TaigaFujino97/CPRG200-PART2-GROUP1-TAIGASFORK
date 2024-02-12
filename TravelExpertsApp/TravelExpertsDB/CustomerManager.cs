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

        public static bool EmailExists(TravelExpertsContext db, string email)
        {
                bool exists = db.Customers.Any(cst => cst.CustEmail.ToLower() == email.ToLower());
                return exists;
        }
        public static Customer GetCustomerData(TravelExpertsContext db, int? id)
        {
            var cust = db.Customers.SingleOrDefault(cst => cst.CustomerId == id);
            return cust;
        }
    }
}
