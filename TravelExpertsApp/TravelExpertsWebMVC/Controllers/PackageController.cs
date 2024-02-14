using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Security.Claims;
using TravelExpertsDB;
using TravelExpertsWebMVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
                int? customerId = HttpContext.Session.GetInt32("CustomerId");
                if (package != null && customerId != null)
                {
                    TempData["PackageId"] = package.PackageId;
                    PrebookingViewModel viewModel = new PrebookingViewModel();
                    viewModel.PkgName = package.PkgName;
                    viewModel.PkgDesc = package.PkgDesc;
                    viewModel.PkgStartDate = package.PkgStartDate;
                    viewModel.PkgEndDate = package.PkgEndDate;
                    viewModel.PkgBasePrice = package.PkgBasePrice;
                    viewModel.PackageId = package.PackageId;
                    viewModel.CustomerId = (int)customerId;
                    List<TripType> types = BookingDB.GetTripTypes(db!);
                    ViewBag.Types = new SelectList(types);
                    return View(viewModel); // return the slipid to the post method

                }
            }
            catch (Exception)
            {
                TempData["Message"] = "Database connection error. Try again later.";
                TempData["IsError"] = true;
            }
            return RedirectToAction("Login", "Account");
        }

        [Authorize]

        [HttpPost]
        [Authorize]
        public ActionResult CreateBooking(PrebookingViewModel viewModel)
        {
            if (viewModel.TravelerCount != null && viewModel.TravelerCount > 0)
            {
                int? customerId = HttpContext.Session.GetInt32("CustomerId");
                Booking booking = BookingDB.CreateBooking((int)customerId, viewModel.PackageId, (int)viewModel.TravelerCount);
                BookingDB.SaveBooking(db, booking);
                return RedirectToAction("OrderHistory", "Account");
            }
            else
            {
                return RedirectToAction("Index", "Package");
            }
        }


        [HttpPost]
        [Authorize]
        public ActionResult ChangeNum(decimal baseP, int numT) // filter by docks
        {
            numT = Math.Max(numT, 1);

            return ViewComponent("PrebookingPrice", new { basePrice = baseP, numTravel = numT });

        }
    }
}
