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
    public class TrackService : ITrackService
    {
        private readonly ITrackRepo _trackRepo;
        private readonly IMapper _mapper;

        public TrackService(ITrackRepo ticketRepo, IMapper mapper)
        {
            _trackRepo = ticketRepo;
            _mapper = mapper;
        }

        public async Task<TrackDTO> AddTrack(Track addedTrack)
        {
            var track = await _trackRepo.AddTrack(addedTrack);
            return _mapper.Map<TrackDTO>(track);
        }

        public async Task<bool> DeleteTrack(Guid id)
        {
            bool deleted = await _trackRepo.DeleteTrack(id);
            return deleted;
        }

        public async Task<TrackDTO> GetTrack(Guid id)
        {
            var track = await _trackRepo.GetTrack(id);
            return _mapper.Map<TrackDTO>(track);
        }

        public async Task<IEnumerable<TrackAdminViewDTO>> GetAdminTracks()
        {
            var track = await _trackRepo.GetTracks();
            return _mapper.Map<IEnumerable<TrackAdminViewDTO>>(track);
        }

        public async Task<IEnumerable<TrackDTO>> GetTracks(TrackParams _filters)
        {
                var tracks = await _trackRepo.GetTracks(_filters.StartingCityId, _filters.DestinationCityId, _filters.Date);
                return _mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }

        public async Task<IEnumerable<TrackDTO>> GetTracks()
        {
            var tracks = await _trackRepo.GetTracks();
            return _mapper.Map<IEnumerable<TrackDTO>>(tracks);
        }

        public async Task<TrackDTO> ModifyTrack(TrackToModifyDTO modifiedTrack, Guid id)
        {
            var oldTrack = await _trackRepo.GetTrack(id);
            _mapper.Map(modifiedTrack, oldTrack);
            await _trackRepo.ModifyTrack(oldTrack);
            return _mapper.Map<TrackDTO>(oldTrack);
        }

        public async Task<bool> IsCityInTracks(Guid id)
        {
            bool isInTracks = await _trackRepo.IsCityInTracks(id);
            return isInTracks;
        }
    }
}
