using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickabusWebApp.RequestBody;
using TickabusWebApp.Services;

namespace TickabusWebApp.Controllers
{
    [Authorize]
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

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Guid trackId)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var ticket = await _ticketService.CreateTicket(trackId, userId);

            return new JsonResult(ticket);

        }
    }
}