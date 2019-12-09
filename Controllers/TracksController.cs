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

        [Authorize(Roles = "admin")]
        [HttpPost("addtrack")]
        public async Task<IActionResult> AddTrack(TrackAddDTO trackToAdd)
        {
            var track = new Track
            {
                Date = DateTime.ParseExact(trackToAdd.Date, "yyyy-MM-dd HH:mm", null),
                StartingCityId = trackToAdd.StartingCityId,
                DestinationCityId = trackToAdd.DestinationCityId,
                Distance = trackToAdd.Distance
            };

            var freshlyAddedTrack = await _trackService.AddTrack(track);

            return new JsonResult(freshlyAddedTrack);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyTrack(TrackToModifyDTO modifiedTrack, Guid id)
        {
            var oldTrack = _trackService.GetTrack(id);

            if (oldTrack is null)
                return BadRequest("Something went wrong with gathering track");

            modifiedTrack.Date = DateTime.ParseExact(modifiedTrack.FakeDate, "yyyy-MM-dd HH:mm", null);
            modifiedTrack.StartingCityId = Guid.Parse(modifiedTrack.FakeStartingCityId);
            modifiedTrack.DestinationCityId = Guid.Parse(modifiedTrack.FakeDestinationCityId);

            var freshlyModifiedTrack = await _trackService.ModifyTrack(modifiedTrack, id);

            return new JsonResult(freshlyModifiedTrack);
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

        [Authorize(Roles = "admin")]
        [HttpGet("noparams")]
        public async Task<IActionResult> GetTracks()
        {
            var tracks = await _trackService.GetAdminTracks();

            return new JsonResult(tracks);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(Guid id)
        {
            bool isSaved = await _trackService.DeleteTrack(id);

            if (isSaved)
                return NoContent();

            return BadRequest("Deletion failed");
        }

    }
}