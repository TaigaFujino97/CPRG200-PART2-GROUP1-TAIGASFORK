using Microsoft.AspNetCore.Mvc;
using TravelExpertsDB;

namespace TravelExpertsWebMVC.Controllers
{
    public class ContactController : Controller
    {
        private TravelExpertsContext? db { get; set; }
        // added constructor
        public ContactController(TravelExpertsContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Agency> agencies = new List<Agency>();
            agencies = db.Agencies.Select(x => x).ToList();
            return View(agencies);
        }
    }
}