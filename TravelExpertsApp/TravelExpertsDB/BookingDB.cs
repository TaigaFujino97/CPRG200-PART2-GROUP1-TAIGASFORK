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
    }
}
