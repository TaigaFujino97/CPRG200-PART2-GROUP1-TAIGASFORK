using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int id)
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Book()
        //{
        //    int? custId = HttpContext.Session.GetInt32("CustomerId");
        //}
    }
}
