using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsDB
{
    public class OrderDB
    {
        public OrderDTO CreateOrder(int bookId, DateTime? date, double? travellers, int? packId, string packName, decimal packPrice) 
        {
            decimal orderTotal = packPrice * (decimal)travellers;
            OrderDTO order = new OrderDTO()
            {
                BookingID = bookId,
                OrderDate = date,
                TravelerCount = travellers,
                PackageId = packId,
                PackageName = packName,
                PackagePrice = packPrice,
                OrderTotal = orderTotal
            };
            return order;
        }

        public OrderDTO GetOrderDetails(TravelExpertsContext db, int? id)
        {
            // Retrieve bookings for the specified customer
            Booking booking = db.Bookings.FirstOrDefault(b => b.BookingId == id)!;

            // Create a list to store OrderDTO objects
            OrderDTO order = new OrderDTO()
            {
                BookingID = booking.BookingId,
                OrderDate = booking.BookingDate,
                TravelerCount = booking.TravelerCount,
                PackageId = booking.PackageId
            };

            // Retrieve package information
            Package package = db.Packages.FirstOrDefault(p => p.PackageId == booking.PackageId);
            if (package != null)
            {
                order.PackageName = package.PkgName;
                order.PackagePrice = package.PkgBasePrice;
                order.OrderTotal = (decimal)order.TravelerCount * order.PackagePrice;
            }

            // Return the OrderDTO object
            return order;

        }
    }
}
