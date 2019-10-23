using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.Services;

namespace TickabusWebApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(Guid id)
        {
            var city = await _cityService.GetCity(id);

            return new JsonResult(city);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityService.GetCities();

            return new JsonResult(cities);
        }

        [HttpPost("addcity")]
        public async Task<IActionResult> AddCity(CityDTO addedCity)
        {

            if (await _cityService.CityExists(addedCity.Name))
                return BadRequest("City exists");

            var cityToAdd = new City
            {
                Name = addedCity.Name
            };

            var freshlyAddedCity = await _cityService.AddCity(cityToAdd);

            return new JsonResult(freshlyAddedCity);
        }


    }
}