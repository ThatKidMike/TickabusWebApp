using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;

namespace TickabusWebApp.Services
{
    public interface ICityService
    {
        Task<CityDTO> GetCity(Guid id);
        Task<IEnumerable<CityDTO>> GetCities();
        Task<CityDTO> AddCity(City city);
        Task<City> CityExists(string name);
        Task<bool> DeleteCity(Guid id);

    }
}
