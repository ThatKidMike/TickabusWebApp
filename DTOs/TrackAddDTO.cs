using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.DTOs
{
    public class TrackAddDTO
    {
        public DateTime Date { get; set; }
        public string StartingCity { get; set; }
        public string DestinationCity { get; set; }
        public int Distance { get; set; }

    }
}
