using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickabusWebApp.RequestBody;
using TickabusWebApp.Services;

namespace TickabusWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {

        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrack(Guid id)
        {
            var track = await _trackService.GetTrack(id);

            return new JsonResult(track);
        }

        [HttpGet]
        public async Task<IActionResult> GetTracks([FromQuery] TrackParams _filters)
        {
            var tracks = await _trackService.GetTracks(_filters);

            return new JsonResult(tracks);
        }

    }
}