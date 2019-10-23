using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.RequestBody
{
    public class TrackParams
    {
        public Guid StartingCityId { get; set; }
        public Guid DestinationCityId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
