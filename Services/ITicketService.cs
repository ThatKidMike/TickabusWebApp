using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.RequestBody;

namespace TickabusWebApp.Services
{
    public interface ITicketService
    {

        Task<TicketDTO> GetTicket(Guid id);
        Task<IEnumerable<TicketDTO>> GetUserTickets(Guid id);
        Task<IEnumerable<TicketDTO>> GetTickets(TicketParams _filters);
        Task<TicketDTO> CreateTicket(Guid trackId, Guid UserId);

    }
}
