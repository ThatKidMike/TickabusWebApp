using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.DTOs
{
    public class TrackDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Distance { get; set; }

    }
}
