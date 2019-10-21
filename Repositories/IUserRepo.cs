using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.Models;

namespace TickabusWebApp.Repositories
{
    public interface IUserRepo
    {
        Task<User> GetUser(Guid id);
    }
}
