using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisteredUserDTO registeredUser)
        {

            registeredUser.Username = registeredUser.Username.ToLower();

            if (await _authService.UserExists(registeredUser.Username))
                return BadRequest("Username already exists");
            else if (await _authService.EmailExists(registeredUser.Email))
                return BadRequest("Submitted email already exists");

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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginedUserDTO loginedUser)
        {
            var userToLogin = await _authService.Login(loginedUser.Username.ToLower(), loginedUser.Password);

            if (userToLogin is null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userToLogin.Id.ToString()),
                new Claim(ClaimTypes.Name, userToLogin.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });

        }

    }
}