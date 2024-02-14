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
    }
}
