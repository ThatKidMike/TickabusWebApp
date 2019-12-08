using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string role { get; set; } = "user";

        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
