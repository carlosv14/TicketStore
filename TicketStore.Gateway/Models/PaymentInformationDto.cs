using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketStore.Gateway.Models
{
    public class PaymentInformationDto
    {
        public Guid CardNumber { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime ValidThrough { get; set; }

        public Guid BasketId { get; set; }
    }
}
