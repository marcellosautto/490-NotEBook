using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace NotEBookWeb.Models
{
    public class User
    {
        
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Please Enter A Valid Email Address")]
        public string Email { get; set; }
        [Required]
        [Range(5,20,ErrorMessage ="Password must be between 5-20 characters")]
        public string Password { get; set; }



    }
}
