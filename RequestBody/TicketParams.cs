using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.RequestBody
{
    public class TicketParams
    {
        public Guid Id { get; set; }
        public Guid StartingCityId { get; set; }
        public Guid DestinationCityId { get; set; }
    }
}
