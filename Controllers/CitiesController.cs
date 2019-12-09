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
        public async Task<IActionResult> GetCity(string id)
        {
            var city = await _cityService.GetCity(Guid.Parse(id));

            return new JsonResult(city);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _cityService.GetCities();

            return new JsonResult(cities);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addcity")]
        public async Task<IActionResult> AddCity(CityDTO addedCity)
        {

            if (!(await _cityService.CityExists(addedCity.Name) is null))
                return BadRequest("City exists");

            var cityToAdd = new City
            {
                Name = addedCity.Name
            };

            var freshlyAddedCity = await _cityService.AddCity(cityToAdd);

            return new JsonResult(freshlyAddedCity);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            bool isInTracks = await _cityService.DeleteCity(id);

            if (!isInTracks)
                return NoContent();

            return BadRequest("Deletion failed - city is probably embbeded in tracks");
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyCity(CityModifiedDTO modifiedCity, Guid id)
        {
            var oldCity = await _cityService.GetCity(id);

            if (oldCity is null)
                return BadRequest("Something went wrong with gathering city");

            var freshlyModifiedCity = await _cityService.ModifyCity(modifiedCity, id);

            return new JsonResult(freshlyModifiedCity);

        }


    }
}