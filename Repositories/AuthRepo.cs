using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Database;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public class AuthRepo : IAuthRepo
    {

        private readonly TickabusContext _context;

        public AuthRepo(TickabusContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            return user;

        }

        public async Task<User> Register(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
    }
}
