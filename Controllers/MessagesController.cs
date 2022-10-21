using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers
{
    public class MessagesController : Controller
    {
        private readonly AgencyContext _ctx = new AgencyContext();
        public IActionResult Index()
        {
            AgencyContext _ctx = new AgencyContext();

            List<Info> messages = _ctx.informazioni.ToList();

            return View("Messages", messages);
        }

        public IActionResult Delete(int id)
        {
            Info msgToDelete = _ctx.informazioni.Where(msg => msg.Id == id).FirstOrDefault();

            if (msgToDelete != null)
            {
                _ctx.informazioni.Remove(msgToDelete);
                _ctx.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
