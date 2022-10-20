using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp_travel_agency.Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class AdminController : Controller
    {
        private readonly AgencyContext _ctx = new AgencyContext();

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<PacchettoViaggio> pacchettiViaggi = _ctx.pacchettiViaggi.ToList();

            return View(pacchettiViaggi);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PacchettoViaggio pacchetto = new PacchettoViaggio();

            return View(pacchetto);
        }

        [HttpPost]
        public IActionResult Create(PacchettoViaggio data)
        {
            if (data != null)
            {
                _ctx.pacchettiViaggi.Add(data);
                _ctx.SaveChanges();

                return RedirectToAction("index");
            }
            else
            {
                return NotFound("Ci sono degli errori");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}