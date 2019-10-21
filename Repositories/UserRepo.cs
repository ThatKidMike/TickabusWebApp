using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Database;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly TickabusContext _context;

        public UserRepo(TickabusContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _context.Users.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

            return user;
        }
    }
}
