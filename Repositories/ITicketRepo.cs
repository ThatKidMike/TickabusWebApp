using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public interface ITicketRepo
    {

        Task<Ticket> GetTicket(Guid id);
        Task<IEnumerable<Ticket>> GetUserTickets(Guid id);
        Task<IEnumerable<Ticket>> GetTickets(Guid startCityId, Guid destinationCityId);
        Task<Ticket> CreateTicket(Ticket createdTicket);


    }
}
