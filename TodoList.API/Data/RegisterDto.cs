using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.API.Data
{
	public class RegisterDto
	{
        [Required]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 20 characters.")]
        public required string PasswordHash { get; set; }
    }
}

