using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.Extensions.Logging;

namespace NotEBookWeb.Models
{
    public class User
    {
        
        [Required]

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}
