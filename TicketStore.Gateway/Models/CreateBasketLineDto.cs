using System;

namespace TicketStore.Gateway.Models
{
    public class CreateBasketLineDto
    {
        public Guid BasketId { get; set; }

        public Guid EventId { get; set; }

        public int TicketQuantity { get; set; }

        public EventDto EventDto { get; set; }
    }
}
