using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketStore.EventCatalog.Models;

namespace TicketStore.EventCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private static readonly List<EventDto> Events = new List<EventDto>
        {
            new EventDto
            {
                EventId = new Guid("c5a37aaa-92b4-4c7d-aae7-877e084a5d12"),
                CategoryId = new Guid("20983d00-f2ae-4361-bdad-68f14e46a32c"),
                Artist = "Komander",
                CategoryName = "Conciertos",
                Date = DateTime.Now,
                Price = 200,
                Name = "Concierto 1"
            },
            new EventDto
            {
                EventId = new Guid("e7145866-3b9d-437a-9ef8-a8aaf2d98423"),
                CategoryId = new Guid("20983d00-f2ae-4361-bdad-68f14e46a32c"),
                Artist = "Bad Bunny",
                CategoryName = "Conciertos",
                Date = DateTime.Now,
                Price = 300,
                Name = "Concierto 2"
            },
            new EventDto
            {
                EventId = new Guid("55a434ee-ef2f-4092-af71-2f0d5dcce365"),
                CategoryId = new Guid("20983d00-f2ae-4361-bdad-68f14e46a32c"),
                Artist = "Chayanne",
                CategoryName = "Conciertos",
                Date = DateTime.Now,
                Price = 400,
                Name = "Concierto 3"
            },
        };

        // /events/fkasjdhf
        [HttpGet("{eventId}")]
        public ActionResult<EventDto> GetById(Guid eventId)
        {
            return this.Ok(Events.FirstOrDefault(x => x.EventId == eventId));
        }

        //events?categoryId=fajsdflka
        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> Get([FromQuery] Guid categoryId)
        {
            return this.Ok(Events.Where(x => x.CategoryId == categoryId));
        }
    }
}
