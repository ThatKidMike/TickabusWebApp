﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.DTOs
{
    public class TrackAddDTO
    {
        public string Date { get; set; }
        public Guid StartingCityId { get; set; }
        public Guid DestinationCityId { get; set; }
        public int Distance { get; set; }

    }
}
