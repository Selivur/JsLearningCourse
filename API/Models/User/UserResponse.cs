using Database.Models;

namespace API.Models.User
{
    /// <summary>
    /// Model for user response data.
    /// </summary>
    public class UserResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the login identifier of the user.
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        public required UserRole Role { get; set; }

        /// <summary>
        /// Gets or sets the ID of the current lesson.
        /// </summary>
        public int? CurrentLessonId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the school the user belongs to.
        /// </summary>
        public required int SchoolId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
} 