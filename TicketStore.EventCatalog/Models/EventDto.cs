using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace TicketStore.EventCatalog.Models
{
    public class EventDto
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string Artist { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
