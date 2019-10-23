using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.Repositories;
using TickabusWebApp.RequestBody;

namespace TickabusWebApp.Services
{
    public class TicketService : ITicketService
    {

        private readonly ITicketRepo _ticketRepo;
        private readonly ITrackRepo _trackRepo;
        private readonly ICityRepo _cityRepo;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepo ticketRepo, ITrackRepo trackRepo, ICityRepo cityRepo, IMapper mapper)
        {
            _ticketRepo = ticketRepo;
            _trackRepo = trackRepo;
            _cityRepo = cityRepo;
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

        public async Task<TicketDTO> CreateTicket(Guid trackId, Guid userId)
        {
            Track track = await _trackRepo.GetTrack(trackId);
            City startingCity = await _cityRepo.GetCity(track.StartingCityId);
            City destinationCity = await _cityRepo.GetCity(track.DestinationCityId);

            var createdTicket = new Ticket
            {
                Price = track.Distance * 2,
                StartingCity = startingCity.Name,
                DestinationCity = destinationCity.Name,
                TrackId = trackId,
                UserId = userId
            };

            var ticket = await _ticketRepo.CreateTicket(createdTicket);

            return _mapper.Map<TicketDTO>(ticket);
        }

    }
}
