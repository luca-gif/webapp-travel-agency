using Microsoft.AspNetCore.Mvc;

namespace webapp_travel_agency.Controllers.Guest
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View("Home");
        }

        public IActionResult Trips()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
