using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Repositories;
using TickabusWebApp.RequestBody;

namespace TickabusWebApp.Services
{
    public class TicketService : ITicketService
    {

        private readonly ITicketRepo _ticketRepo;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepo ticketRepo, IMapper mapper)
        {
            _ticketRepo = ticketRepo;
            _mapper = mapper;
        }

        public async Task<TicketDTO> GetTicket(Guid id)
        {
            //odniesienie do repo
            var ticket = await _ticketRepo.GetTicket(id);
            return _mapper.Map<TicketDTO>(ticket);

        }

        public async Task<IEnumerable<TicketDTO>> GetTickets(TicketParams _filters)
        {
            var tickets = await _ticketRepo.GetTickets(_filters.StartingCityId, _filters.DestinationCityId);
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }
    }
}
