using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.Repositories;

namespace TickabusWebApp.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;
        private readonly IMapper _mapper;

        public CityService(ICityRepo cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        public async Task<CityDTO> AddCity(City addedCity)
        {
            var city = await _cityRepo.AddCity(addedCity);
            return _mapper.Map<CityDTO>(city);
        }

        public async Task<bool> CityExists(string name)
        {
            if (!await _cityRepo.CityExists(name))
                return false;

            return true;
        }

        public async Task<IEnumerable<CityDTO>> GetCities()
        {
            var cities = await _cityRepo.GetCities();
            return _mapper.Map<IEnumerable<CityDTO>>(cities);
        }

        public async Task<CityDTO> GetCity(Guid id)
        {
            var city = await _cityRepo.GetCity(id);
            return _mapper.Map<CityDTO>(city);
        }
    }
}
