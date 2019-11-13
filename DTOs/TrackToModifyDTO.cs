using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.DTOs
{
    public class TrackToModifyDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Distance { get; set; }
        public Guid StartingCityId { get; set; }
        public Guid DestinationCityId { get; set; }

    }
}
