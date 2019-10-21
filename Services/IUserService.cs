using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;

namespace TickabusWebApp.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(Guid id);
    }
}
