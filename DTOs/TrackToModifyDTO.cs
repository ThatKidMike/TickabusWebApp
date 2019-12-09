using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.DTOs
{
    public class TrackToModifyDTO
    {
        public string FakeDate { get; set; }
        public int Distance { get; set; }
        public string FakeStartingCityId { get; set; }
        public string FakeDestinationCityId { get; set; }
        public DateTime Date { get; set; }
        public Guid StartingCityId { get; set; }
        public Guid DestinationCityId { get; set; }

    }
}
