using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly AgencyContext _ctx = new AgencyContext();

        public IActionResult Get(string? tripName)
        {
            List<PacchettoViaggio> trips = new List<PacchettoViaggio>();

            if (tripName == null)
            {
                trips = _ctx.pacchettiViaggi.ToList();
            }
            else
            {
                trips = _ctx.pacchettiViaggi.Where(trip => trip.Name.ToLower().Contains(tripName.ToLower())).ToList();
            }

            return Ok(trips.ToList());
        }

        public IActionResult Categories(int? id)
        {
            List<Categoria> categories = new List<Categoria>();

            categories = _ctx.categorie.ToList();

            return Ok(categories.ToList());
        }

        // Ricerca per categoria

        public IActionResult GetByCategory(int? id)
        {
            List<PacchettoViaggio> trips = new List<PacchettoViaggio>();

            if (id != 0)
            {
                trips = _ctx.pacchettiViaggi.Where(t => t.CategoriaId == id).ToList();
            }
            else
            {
                trips = _ctx.pacchettiViaggi.ToList();
            }

            return Ok(trips.ToList());
        }


        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                PacchettoViaggio trip = _ctx.pacchettiViaggi.Where(trip => trip.Id == id).FirstOrDefault();

                return Ok(trip);
            }

        }
    }
}
