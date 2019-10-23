using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.Models
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Price { get; set; }
        public string StartingCity { get; set; }
        public string DestinationCity { get; set; }

        public Guid TrackId { get; set; }
        public virtual Track Track { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
