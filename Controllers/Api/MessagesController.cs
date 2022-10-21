using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Context;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly AgencyContext _ctx = new AgencyContext();

        // POST api/<MessagesController>
        [HttpPost]
        public IActionResult Send([FromBody] Info message)
        {

            if (message == null)
            {
                return BadRequest();
            }
            else
            {
                _ctx.informazioni.Add(message);
                _ctx.SaveChanges();

                return Ok();
            }

        }

    }
}
