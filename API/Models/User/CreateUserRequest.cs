using System.ComponentModel.DataAnnotations;
using Database.Models;

namespace API.Models.User
{
    /// <summary>
    /// Model for creating a new user.
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Gets or sets the login identifier for the user.
        /// </summary>
        [Required]
        public required string Login { get; set; }

        /// <summary>
        /// Gets or sets the password for the user.
        /// </summary>
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the ID of the school the user belongs to.
        /// </summary>
        public int SchoolId { get; set; }
    }
} 