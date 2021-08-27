using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketStore.ShoppingBasket.Models;

namespace TicketStore.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketLinesController : ControllerBase
    {
        [HttpGet("/ShoppingBaskets/{basketId}/BasketLines")]
        public ActionResult<IEnumerable<BasketLineDto>> Get(Guid basketId)
        {
            var basket = Database.Baskets.FirstOrDefault(x => x.BasketId == basketId);
            if (basket == null)
            {
                return this.NotFound();
            }

            var basketLines = Database.BasketLines.Where(x => x.Basket == basketId);
            return this.Ok(basketLines);
        }

        [HttpPost("/ShoppingBaskets/{basketId}/BasketLines")]
        public async Task<ActionResult<BasketLineDto>> Post(Guid basketId, [FromBody] CreateBasketLineDto basketLineForCreation)
        {
            var basket = Database.Baskets.FirstOrDefault(x => x.BasketId == basketId);
            if (basket == null)
            {
                return this.NotFound("No existe el carrito!");
            }

            EventDto eventData = null;
            if (Database.Events.All(x => x.EventId != basketLineForCreation.EventId))
            {
                using (var httpClient = new HttpClient())
                {
                    var response =
                        await httpClient.GetStringAsync(
                            $"http://localhost:33977/events/{basketLineForCreation.EventId}");
                    eventData = JsonConvert.DeserializeObject<EventDto>(response);
                    Database.Events.Add(eventData);
                }
            }

            if (eventData == null)
            {
                return this.Ok("No existe el evento!");
            }

            var basketLine = new BasketLineDto
            {
                EventId = basketLineForCreation.EventId,
                Price = eventData.Price,
                Basket = basketLineForCreation.BasketId,
                TicketQuantity = basketLineForCreation.TicketQuantity,
                BasketLineId = Guid.NewGuid(),
                Event = basketLineForCreation.EventDto
            };
            Database.BasketLines.Add(basketLine);

            return this.Ok(basketLine);
        }
    }
}
