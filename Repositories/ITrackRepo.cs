﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public interface ITrackRepo
    {
        Task<Track> GetTrack(Guid id);
        Task<IEnumerable<Track>> GetTracks(Guid startingCityId, Guid destinationCityId, DateTime date);
        Task<IEnumerable<Track>> GetTracks();
        Task<Track> AddTrack(Track track);
        Task<bool> DeleteTrack(Guid id);
        Task<Track> ModifyTrack(Track modifiedTrack);
        Task<bool> IsCityInTracks(Guid id);



    }
}
