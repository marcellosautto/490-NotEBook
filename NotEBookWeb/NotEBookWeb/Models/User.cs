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
        private string Email { get; set; }

        [Required]
        [StringLength(15,  ErrorMessage = "Name must be 15 or less characters.")]
        private string Username { get; set; }

        [Required]
        [Range(5, 15, ErrorMessage = "Password must be between 5-15 characters.")]
        private string Password { get; set; }

    }
}
