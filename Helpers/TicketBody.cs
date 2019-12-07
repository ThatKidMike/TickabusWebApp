using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.Helpers
{
    public class TicketBody
    { 
        public Guid Id { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
