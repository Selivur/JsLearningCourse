using Database.Models;

namespace Database.Repositories
{
    /// <summary>
    /// Interface for managing User entities in the database
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <returns>A collection of all users</returns>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// Gets a user by their ID
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        /// <returns>The user if found, null otherwise</returns>
        Task<User?> GetByIdAsync(int id);

        /// <summary>
        /// Gets a user by their login
        /// </summary>
        /// <param name="login">The login of the user to retrieve</param>
        /// <returns>The user if found, null otherwise</returns>
        Task<User?> GetByLoginAsync(string login);

        /// <summary>
        /// Gets all students from a specific school
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <returns>A collection of students from the specified school</returns>
        Task<IEnumerable<User>> GetStudentsBySchoolIdAsync(int schoolId);

        /// <summary>
        /// Creates a new user in the database
        /// </summary>
        /// <param name="user">The user entity to create</param>
        /// <returns>The created user with updated ID</returns>
        Task<User> CreateAsync(User user);

        /// <summary>
        /// Updates an existing user in the database
        /// </summary>
        /// <param name="user">The user entity with updated data</param>
        /// <returns>The updated user</returns>
        Task<User> UpdateAsync(User user);

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
        /// <returns>True if the user was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id);
    }
} 