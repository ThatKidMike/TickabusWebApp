using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public interface ITrackRepo
    {
        Task<Track> GetTrack(Guid id);

        Task<IEnumerable<Track>> GetTracks(Guid startingCityId, Guid destinationCityId, DateTime date);

    }
}
