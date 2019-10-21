using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
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

        public async Task<CityDTO> GetCity(Guid id)
        {
            var city = await _cityRepo.GetCity(id);
            return _mapper.Map<CityDTO>(city);
        }
    }
}
