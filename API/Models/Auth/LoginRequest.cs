using System.ComponentModel.DataAnnotations;

namespace API.Models.Auth
{
    public class LoginRequest
    {
        [Required]
        public required string Login { get; set; }

        [Required]
        public required string Password { get; set; }
    }
} 