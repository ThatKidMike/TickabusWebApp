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
        private readonly ITrackService _trackService;

        public CityService(ICityRepo cityRepo, IMapper mapper, ITrackService trackService)
        {
            _cityRepo = cityRepo;
            _trackService = trackService;
            _mapper = mapper;
        }

        public async Task<CityDTO> AddCity(City addedCity)
        {
            var city = await _cityRepo.AddCity(addedCity);
            return _mapper.Map<CityDTO>(city);
        }

        public async Task<City> CityExists(string name)
        {
            var city = await _cityRepo.CityExists(name);
                
            return city;
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

        public async Task<bool> DeleteCity(Guid id)
        {
            bool isInTracks = await _trackService.IsCityInTracks(id);

            if (isInTracks)
                return true;
            else
            {
                await _cityRepo.DeleteCity(id);
                return false;
            }
        }

        public async Task<CityDTO> ModifyCity(CityModifiedDTO modifiedCity, Guid id)
        {
            var oldCity = await _cityRepo.GetCity(id);
            _mapper.Map(modifiedCity, oldCity);
            await _cityRepo.ModifyCity(oldCity);
            return _mapper.Map<CityDTO>(oldCity);
        }
    }
}
