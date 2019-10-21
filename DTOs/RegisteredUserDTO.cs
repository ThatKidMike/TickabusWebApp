using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TickabusWebApp.DTOs
{
    public class RegisteredUserDTO
    {
        [Required(ErrorMessage = "An username must be provided")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A password must be provided")]
        [StringLength(21, MinimumLength = 8, ErrorMessage = "Password must consists of at least 8 characters (21 max)")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A name must be provided")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A surname must be provided")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "An email must be provided")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
