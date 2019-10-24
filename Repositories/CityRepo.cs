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

        public async Task<City> CityExists(string name)
        {
            var city = await _context.Cities.Where(x => x.Name.Equals(name)).FirstOrDefaultAsync();
            return city;
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return cities;
        }

        public async Task<City> GetCity(Guid? id)
        {
            var city = await _context.Cities.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return city;
        }

        public async Task<bool> DeleteCity(Guid id)
        {
            _context.Remove(await _context.Cities.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync());
            int isSaved = await _context.SaveChangesAsync();

            if (isSaved > 0)
                return true;

            return false;
        }
    }
}
