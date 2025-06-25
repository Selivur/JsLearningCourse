using System.ComponentModel.DataAnnotations;
using Database.Models;

namespace API.Models.User
{
    /// <summary>
    /// Model for updating an existing user.
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// Gets or sets the login identifier for the user.
        /// </summary>
        [Required]
        public required string Login { get; set; }

        /// <summary>
        /// Gets or sets the new password for the user.
        /// If null, the password will not be changed.
        /// </summary>
        [MinLength(6)]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        [Required]
        public required UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the ID of the current lesson.
        /// </summary>
        public int? CurrentLessonId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the school the user belongs to.
        /// </summary>
        [Required]
        public required int SchoolId { get; set; }
    }
} 