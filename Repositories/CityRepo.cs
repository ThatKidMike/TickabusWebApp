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

        public async Task<City> AddCity(City city)
        {
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();

            return city;
        }

        public async Task<bool> CityExists(string name)
        {
            if (await _context.Cities.Where(x => x.Name.Equals(name)).FirstOrDefaultAsync() is null)
                return false;

            return true;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();

            return cities;
        }

        public async Task<City> GetCity(Guid id)
        {
            var city = await _context.Cities.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return city;

        }
    }
}
