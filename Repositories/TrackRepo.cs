﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Database;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public class TrackRepo : ITrackRepo
    {

        private readonly TickabusContext _context;

        public TrackRepo(TickabusContext context)
        {
            _context = context;
        }

        public async Task<Track> GetTrack(Guid id)
        {
            var track = await _context.Tracks.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return track;
        }

        public async Task<IEnumerable<Track>> GetTracks(Guid startingCityId, Guid destinationCityId, DateTime date)
        {

            var tracks = await _context.Tracks.Where(x => x.StartingCityId.Equals(startingCityId)
                                                    && x.DestinationCityId.Equals(destinationCityId)
                                                    && x.Date.Hour.CompareTo(date.Hour) >= 0 
                                                    && x.Date.Minute.CompareTo(date.Minute) >= 0
                                                    && x.Date.Date.CompareTo(date.Date) == 0).ToListAsync();
            return tracks;
        }

    }
}