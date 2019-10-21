using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Database;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public class CityRepo : ICityRepo
    {
        private readonly TickabusContext _context;

        public CityRepo(TickabusContext context)
        {
            _context = context;
        }
        public async Task<City> GetCity(Guid id)
        {
            var city = await _context.Cities.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return city;

        }
    }
}
