using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            List<Info> messages = _ctx.informazioni.Include("PacchettoViaggio").OrderByDescending(m => m.Id).ToList();

            return View("Messages", messages);
        }

        public IActionResult ShowMessage(int id)
        {
            Info msg = _ctx.informazioni.Where(msg => msg.Id == id).Include("PacchettoViaggio").FirstOrDefault();

            return View("MessageDetail", msg);
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
