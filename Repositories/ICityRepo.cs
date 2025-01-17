﻿using System;
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
        Task<City> CityExists(string name);
        Task<bool> DeleteCity(Guid id);
        Task<City> ModifyCity(City modifiedCity);

    }
}
