using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.RequestBody;
using TickabusWebApp.Services;

namespace TickabusWebApp.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;
        private readonly ICityService _cityService;

        public TracksController(ITrackService trackService, ICityService cityService)
        {
            _trackService = trackService;
            _cityService = cityService;
        }

        [HttpPost("addtrack")]
        public async Task<IActionResult> AddTrack([FromQuery] TrackAddDTO trackToAdd)
        {
            var startingCity = await _cityService.CityExists(trackToAdd.StartingCity);
            var destinationCity = await _cityService.CityExists(trackToAdd.DestinationCity);

            if (startingCity is null)
                return BadRequest("Starting city doesn't exist");

            if (destinationCity is null)
                return BadRequest("Destination city doesn't exist");

            var track = new Track
            {
                Date = trackToAdd.Date,
                StartingCityId = startingCity.Id,
                DestinationCityId = destinationCity.Id,
                Distance = trackToAdd.Distance
            };

            var freshlyAddedTrack = await _trackService.AddTrack(track);

            return new JsonResult(freshlyAddedTrack);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("modifytrack")]
        public async Task<IActionResult> ModifyTrack([FromQuery] TrackToModifyDTO values)
        {
            var modifiedTrack = await _trackService.ModifyTrack(values);
            return new JsonResult(modifiedTrack);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrack(Guid id)
        {
            var track = await _trackService.GetTrack(id);

            if (track is null)
                return BadRequest("This track doesn't exist");

            return new JsonResult(track);
        }

        [HttpGet]
        public async Task<IActionResult> GetTracks([FromQuery] TrackParams _filters)
        {
            var tracks = await _trackService.GetTracks(_filters);

            return new JsonResult(tracks);
        }

        [HttpGet("noparams")]
        public async Task<IActionResult> GetTracks()
        {
            var tracks = await _trackService.GetTracks();

            return new JsonResult(tracks);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTrack(Guid id)
        {
            bool isSaved = await _trackService.DeleteTrack(id);

            if (isSaved)
            return Ok("Track succesfully deleted");

            return BadRequest("Deletion failed");
        }

    }
}