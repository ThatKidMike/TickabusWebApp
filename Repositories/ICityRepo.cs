using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public interface ICityRepo
    {

        Task<IEnumerable<City>> GetCities();

        Task<City> GetCity(Guid? id);

        Task<City> AddCity(City city);

        Task<bool> CityExists(string name);

    }
}
