using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsDB
{
    public class BookingDB
    {
        public static List<TripType> GetTripTypes(TravelExpertsContext db)
        {
            List <TripType> types = db.TripTypes.OrderBy(x => x.Ttname).ToList();
            return types;
        }
        public static Booking CreateBooking(TravelExpertsContext db, Booking booking, int? custId, int? packId, DateTime now)
        {
            booking.BookingDate = now;
            booking.CustomerId = custId;
            booking.PackageId = packId;
            db.Bookings.Add(booking);
            db.SaveChanges();
            return booking;
        }
        public static Booking FindBooking(TravelExpertsContext db, int? bookingId)
        {
            Booking booking = db.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            return booking;
        }
    }
}