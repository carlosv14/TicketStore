using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using TicketStore.Gateway.Models;
using TicketStore.Gateway.Services;

namespace TicketStore.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly IShoppingBasketService _shoppingBasketService;

        public BasketsController(IShoppingBasketService shoppingBasketService)
        {
            _shoppingBasketService = shoppingBasketService;
        }

        [HttpGet("{basketId}")]
        public async Task<ActionResult<BasketDto>> GetBasketById(Guid basketId)
        {
            var result = await _shoppingBasketService.GetBasketByIdAsync(basketId);
            return this.Ok(result);
        }

        [HttpPost("{basketId}/BasketLines")]
        public async Task<ActionResult<BasketLineDto>> Post(Guid basketId, [FromBody] CreateBasketLineDto basketLineForCreation)
        {
            return await _shoppingBasketService.AddEventToBasketAsync(basketId, basketLineForCreation);
        }

        [HttpPost("{basketId}/pay")]
        public ActionResult PostPayment(Guid basketId, [FromBody] PaymentInformationDto paymentInformation)
        {
            try
            {
                paymentInformation.BasketId = basketId;
                var json = JsonConvert.SerializeObject(paymentInformation);
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    Port = 5672
                };

                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("payment-queue", false, false, false, null);
                        var body = Encoding.UTF8.GetBytes(json);
                        channel.BasicPublish(string.Empty, "payment-queue", null, body);
                    }
                }

                return this.Ok(Guid.NewGuid());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
