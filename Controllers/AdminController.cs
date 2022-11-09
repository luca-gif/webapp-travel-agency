using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webapp_travel_agency.Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
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
            List<PacchettoViaggio> pacchettiViaggi = _ctx.pacchettiViaggi.Include("Categoria").ToList();

            return View(pacchettiViaggi);
        }

        public IActionResult Show(int id)
        {
            PacchettoViaggio trip = _ctx.pacchettiViaggi.Include("Categoria").Include("Messages").Where(t => t.Id == id).FirstOrDefault();

            return View(trip);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Wrapper wrapper = new Wrapper();

            wrapper.PacchettoViaggio = new PacchettoViaggio();
            wrapper.Categoria = _ctx.categorie.ToList();

            return View(wrapper);
        }

        [HttpPost]
        public IActionResult Create(Wrapper data)
        {
            if (!ModelState.IsValid)
            {
                data.Categoria = _ctx.categorie.ToList();

                return View(data);
            }


            _ctx.pacchettiViaggi.Add(data.PacchettoViaggio);

            _ctx.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Wrapper wrapper = new Wrapper();

            wrapper.PacchettoViaggio = _ctx.pacchettiViaggi.Find(id);
            wrapper.Categoria = _ctx.categorie.ToList();

            return View("Edit", wrapper);
        }

        [HttpPost]
        public IActionResult Update(int id, Wrapper data)
        {
            data.Categoria = _ctx.categorie.ToList();

            if (ModelState.IsValid)
            {
                PacchettoViaggio pacchettoDaModificare = _ctx.pacchettiViaggi.Where(p => p.Id == id).FirstOrDefault();

                pacchettoDaModificare.Name = data.PacchettoViaggio.Name;
                pacchettoDaModificare.Image = data.PacchettoViaggio.Image;
                pacchettoDaModificare.Price = data.PacchettoViaggio.Price;
                pacchettoDaModificare.Description = data.PacchettoViaggio.Description;
                pacchettoDaModificare.Date = data.PacchettoViaggio.Date;
                pacchettoDaModificare.CategoriaId = data.PacchettoViaggio.CategoriaId;
                _ctx.SaveChanges();

                return RedirectToAction("index");
            }

            else
            {
                data.Categoria = _ctx.categorie.ToList();

                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(PacchettoViaggio data)
        {
            if (data != null)
            {
                _ctx.pacchettiViaggi.Remove(data);
                _ctx.SaveChanges();

                return RedirectToAction("index");
            }

            else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}