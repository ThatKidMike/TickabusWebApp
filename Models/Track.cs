using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.Models
{
    public class Track
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public int Distance { get; set; }

        [ForeignKey(nameof(CityStart)), Column(Order = 0)]
        public Guid? StartingCityId { get; set; }
        [ForeignKey(nameof(CityDestination)), Column(Order = 1)]
        public Guid? DestinationCityId { get; set; }
        
        public virtual City CityStart { get; set; }
        public virtual City CityDestination { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }   
}
