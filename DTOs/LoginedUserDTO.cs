using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TickabusWebApp.DTOs
{
    public class LoginedUserDTO
    {
        [Required(ErrorMessage = "An username must be provided")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A password must be provided")]
        [StringLength(21, MinimumLength = 8, ErrorMessage = "Password must consists of at least 8 characters (21 max)")]
        public string Password { get; set; }
    }
}
