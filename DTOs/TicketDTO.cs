﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.DTOs
{
    public class TicketDTO
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string StartingCity { get; set; }
        public string DestinationCity { get; set; }
        public DateTime Date { get; set; }

    }
}
