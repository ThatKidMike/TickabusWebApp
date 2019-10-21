using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickabusWebApp.RequestBody;
using TickabusWebApp.Services;

namespace TickabusWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(Guid id)
        {
            var ticket = await _ticketService.GetTicket(id);

            return new JsonResult(ticket);
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets([FromQuery] TicketParams _filters)
        {
            var tickets = await _ticketService.GetTickets(_filters);

            return new JsonResult(tickets);
        }
    }
}