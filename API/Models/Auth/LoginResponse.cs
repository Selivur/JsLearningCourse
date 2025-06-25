using Database.Models;

namespace API.Models.Auth
{
    /// <summary>
    /// Response model for user authentication containing JWT token and user information.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// JWT token for authenticated user.
        /// </summary>
        public required string Token { get; set; }

        /// <summary>
        /// User's role in the system.
        /// </summary>
        public required UserRole Role { get; set; }

        /// <summary>
        /// Current page or lesson ID the user is on.
        /// </summary>
        public int? CurrentPage { get; set; }

        /// <summary>
        /// ID of the school the user belongs to.
        /// </summary>
        public int SchoolId { get; set; }
    }
} 