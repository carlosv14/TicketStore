using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.ShoppingBasket.Models
{
    public class BasketLineDto
    {
        public Guid BasketLineId { get; set; }

        public Guid Basket { get; set; }

        public Guid EventId { get; set; }

        public decimal Price { get; set; }

        public int TicketQuantity { get; set; }

        public EventDto Event { get; set; }
    }
}
