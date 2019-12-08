using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;

namespace TickabusWebApp.Services
{
    public interface IAuthService
    {
        Task<UserDTO> Login(string username, string password);
        Task<UserDTO> Register(User user, string password);
        Task<bool> UserExists(string username);
        Task<bool> EmailExists(string email);
        Task<string> UserRole(Guid id);
    }
}
