using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsDB
{
    public static class CustomerManager
    {
        public static Customer Authenticate(TravelExpertsContext db, string username, string password)
        {
            var cust = db.Customers.SingleOrDefault(cst => cst.Username == username
                                                    && cst.Password == password);
            return cust; //this will either be null or an object
        }

        public static void CreateCustomer(TravelExpertsContext db, Customer customer)
        {
                db.Customers.Add(customer);
                db.SaveChanges();
        }

        public static bool UsernameExists(TravelExpertsContext db, string username)
        {
                bool exists = db.Customers.Any(cst => cst.Username.ToLower() == username.ToLower());
                return exists;
        }
    }
}
