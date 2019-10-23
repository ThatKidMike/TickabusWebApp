using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Database;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public class TicketRepo : ITicketRepo
    {
        private readonly TickabusContext _context;

        public TicketRepo(TickabusContext context)
        {
            _context = context;
        }

        public async Task<Ticket> GetTicket(Guid id)
        {
            var ticket = await _context.Tickets.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTickets(Guid startCityId, Guid destinationCityId)
        {
            var tickets = await _context.Tickets.Where(x => x.Track.StartingCityId.Equals(startCityId) 
                    && x.Track.DestinationCityId.Equals(destinationCityId)).ToListAsync();

            return tickets;
        }

        public async Task<Ticket> CreateTicket(Ticket createdTicket)
        {
            await _context.Tickets.AddAsync(createdTicket);
            await _context.SaveChangesAsync();

            return createdTicket;
        }

    }
}
