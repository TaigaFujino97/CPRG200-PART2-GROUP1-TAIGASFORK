using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelExpertsDB;

namespace TravelExpertsWebMVC.Controllers
{
    public class PackageController : Controller
    {
        private TravelExpertsContext? db { get; set; }
        // added constructor
        public PackageController(TravelExpertsContext db)
        {
            this.db = db;
        }
        public ActionResult Index(int id)
        {
            List<Package> packages = PackageDB.GetPackages(db!);
            return View(packages);
        }

        [Authorize]
        public ActionResult Book(int id)
        {
            Package? package = null;
            try
            {
                package = PackageDB.GetPackageById(db!, id); // get slipid of selected slip from list
                if (package != null)
                {
                    TempData["PackageId"] = package.PackageId;
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
            }
            return View(package); // return the slipid to the post method
        }

        [Authorize]
        public ActionResult CreateBooking(int id)
        {
            try
            {
                //List<TripType> types = BookingDB.GetTripTypes(db!);
                //var list = new SelectList(types, "TripTypeId", "Ttname").ToList();
                //list.Insert(0, new SelectListItem("X", "Optional"));
                //ViewBag.Types = list;
                List<TripType> types = BookingDB.GetTripTypes(db!);
                SelectList tripTypeSelectList = new SelectList(types, "TripTypeId", "Ttname");
                ViewBag.Types = tripTypeSelectList;
            }
            catch (Exception)
            {
                TempData["Message"] = "Unable to connect to the database. Please try refreshing the page.";
                TempData["IsError"] = true;
            }
            return View(new Booking());
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking newBooking)
        {
            int? customerId = HttpContext.Session.GetInt32("CustomerId");
            int? packageId = Convert.ToInt32(TempData["PackageId"]);
            DateTime bookingDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    Booking createdBooking = BookingDB.CreateBooking(db, newBooking, customerId, packageId, bookingDate);
                    TempData["BookingId"] = createdBooking.BookingId;
                }
                catch (Exception)
                {
                    TempData["Message"] = "There was a problem with booking. Please try again later.";
                    TempData["IsError"] = true;
                    return RedirectToAction("Account", "Account");
                }
                return RedirectToAction("Confirmation", "Package");
            }
            else
            {
                TempData["Message"] = "There was a problem with booking your package. Please try again later.";
                TempData["IsError"] = true;
                return View(newBooking);
            }
        }

        public ActionResult Confirmation()
        {
            string name = User.Identity.Name!;
            int bookingId = Convert.ToInt32(TempData["BookingId"]);
            Booking createdBooking = BookingDB.FindBooking(db, bookingId);
            int? packageId = createdBooking.PackageId;
            DateTime? orderDate = createdBooking.BookingDate;
            double? travellers = createdBooking.TravelerCount;
            Package bookedPackage = PackageDB.GetPackageById(db, (int)packageId!);
            string packageName = bookedPackage.PkgName;
            decimal price = bookedPackage.PkgBasePrice;
            OrderDB orderDB = new OrderDB();
            OrderDTO order = orderDB.CreateOrder(bookingId, orderDate, travellers, packageId, packageName, price);
            if(order == null)
            {
                TempData["Message"] = "Booking details not found.";
                TempData["IsError"] = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = $"Thank you for your order {name}!";
            }
            return View(order);
        }
    }
}
