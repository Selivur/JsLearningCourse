using API.Models.Auth;
using API.Models.User;
using Database.Models;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Interface for managing user-related operations.
    /// Defines methods for user authentication, creation, and management.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Verifies user credentials and returns authentication response if successful.
        /// </summary>
        /// <param name="request">The login request containing user credentials.</param>
        /// <returns>The login response containing user information and JWT token if authentication is successful; otherwise, null.</returns>
        Task<LoginResponse?> VerifyUserAsync(LoginRequest request);

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A collection of user response models.</returns>
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();

        /// <summary>
        /// Retrieves a specific user by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>The user response model if found; otherwise, null.</returns>
        Task<UserResponse?> GetUserByIdAsync(int id);

        /// <summary>
        /// Retrieves a user by their login identifier.
        /// </summary>
        /// <param name="login">The login identifier of the user to retrieve.</param>
        /// <returns>The user response model if found; otherwise, null.</returns>
        Task<UserResponse?> GetUserByLoginAsync(string login);

        /// <summary>
        /// Retrieves all students associated with a specific school.
        /// </summary>
        /// <param name="schoolId">The unique identifier of the school.</param>
        /// <returns>A collection of student response models belonging to the specified school.</returns>
        Task<IEnumerable<UserResponse>> GetStudentsBySchoolIdAsync(int schoolId);

        /// <summary>
        /// Creates a new user in the system with the specified credentials.
        /// </summary>
        /// <param name="request">The user creation request model.</param>
        /// <returns>The created user response model.</returns>
        Task<UserResponse> CreateUserAsync(CreateUserRequest request);

        /// <summary>
        /// Updates an existing user's information and optionally their password.
        /// </summary>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="request">The user update request model.</param>
        /// <returns>The updated user response model.</returns>
        Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest request);

        /// <summary>
        /// Removes a user from the system by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        /// <returns>True if the user was successfully deleted; otherwise, false.</returns>
        Task<bool> DeleteUserAsync(int id);

        /// <summary>
        /// Verifies if the provided password matches the user's stored credentials.
        /// </summary>
        /// <param name="user">The user entity to verify credentials for.</param>
        /// <param name="password">The password to verify against the user's stored credentials.</param>
        /// <returns>True if the password matches; otherwise, false.</returns>
        Task<bool> VerifyPasswordAsync(User user, string password);
    }
} 