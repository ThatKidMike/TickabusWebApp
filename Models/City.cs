using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.Models
{
    public class City
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        [InverseProperty(nameof(Track.CityStart))]
        public virtual ICollection<Track> TracksStart { get; set; }

        [InverseProperty(nameof(Track.CityDestination))]
        public virtual ICollection<Track> TracksDestination { get; set; }
    }
}
