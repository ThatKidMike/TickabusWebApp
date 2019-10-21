using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.Services;

namespace TickabusWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisteredUserDTO registeredUser)
        {

            registeredUser.Username = registeredUser.Username.ToLower();

            if (await _authService.UserExists(registeredUser.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = registeredUser.Username,
                Name = registeredUser.Name,
                Surname = registeredUser.Surname,
                Email = registeredUser.Email
            };

            var createdUser = await _authService.Register(userToCreate, registeredUser.Password);

            return new JsonResult(createdUser);
        }

    }
}