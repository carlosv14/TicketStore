using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.ShoppingBasket.Models;

namespace TicketStore.ShoppingBasket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingBasketsController : ControllerBase
    {

        [HttpGet("{basketId}")]
        public ActionResult<BasketDto> Get(Guid basketId)
        {
            var basket = Database.Baskets.FirstOrDefault(x => x.BasketId == basketId);
            if (basket == null)
            {
                return this.NotFound($"No se encontró un basket con id: {basketId}");
            }

            return this.Ok(basket);
        }

        [HttpPost]
        public ActionResult<BasketDto> Post([FromBody] CreateBasketDto basketForCreation)
        {
            var basket = new BasketDto
            {
                UserId = basketForCreation.UserId,
                BasketId = Guid.NewGuid()
            };

            Database.Baskets.Add(basket);
            return this.Ok(basket);
        }
    }
}
