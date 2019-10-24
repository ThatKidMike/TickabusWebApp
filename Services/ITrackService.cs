using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.RequestBody;

namespace TickabusWebApp.Services
{
    public interface ITrackService
    {

        Task<TrackDTO> GetTrack(Guid id);
        Task<IEnumerable<TrackDTO>> GetTracks(TrackParams _filters);
        Task<IEnumerable<TrackDTO>> GetTracks();
        Task<TrackDTO> AddTrack(Track track);
        Task <bool> DeleteTrack(Guid id);

    }
}
