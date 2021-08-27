using System;
using System.Collections.Generic;

namespace TicketStore.Gateway.Models
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<EventDto> Events { get; set; }
    }
}
