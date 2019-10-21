using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public interface IAuthRepo
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user);
        Task<bool> UserExists(string username);
    }
}
