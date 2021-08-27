using System;
using System.Collections.Generic;

namespace TicketStore.Gateway.Models
{
    public class BasketDto
    {
        public Guid BasketId { get; set; }

        public Guid UserId { get; set; }

        public int NumberOfItems { get; set; }

        public IEnumerable<BasketLineDto> BasketLines { get; set; }
    }
}
