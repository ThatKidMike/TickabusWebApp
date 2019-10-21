using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;

namespace TickabusWebApp.Services
{
    public interface ICityService
    {
        Task<CityDTO> GetCity(Guid id);
    }
}
