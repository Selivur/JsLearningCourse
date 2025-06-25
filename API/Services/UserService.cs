using API.Models.Auth;
using API.Models.User;
using API.Services.Interfaces;
using Database.Models;
using Database.Repositories;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace API.Services
{
    /// <summary>
    /// Implementation of the <see cref="IUserService"/> interface.
    /// Provides functionality for user management, authentication, and password handling.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The repository for user data operations.</param>
        /// <param name="configuration">The application configuration.</param>
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<LoginResponse?> VerifyUserAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByLoginAsync(request.Login);
            if (user == null)
                return null;

            var hashedPassword = HashPassword(request.Password);
            if (user.Password != hashedPassword)
                return null;

            return new LoginResponse
            {
                Token = GenerateJwtToken(user),
                Role = user.Role,
                CurrentPage = user.CurrentLessonId,
                SchoolId = user.SchoolId
            };
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(MapToResponse);
        }

        /// <inheritdoc/>
        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? MapToResponse(user) : null;
        }

        /// <inheritdoc/>
        public async Task<UserResponse?> GetUserByLoginAsync(string login)
        {
            var user = await _userRepository.GetByLoginAsync(login);
            return user != null ? MapToResponse(user) : null;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserResponse>> GetStudentsBySchoolIdAsync(int schoolId)
        {
            var students = await _userRepository.GetStudentsBySchoolIdAsync(schoolId);
            return students.Select(MapToResponse);
        }

        /// <inheritdoc/>
        public async Task<UserResponse> CreateUserAsync(CreateUserRequest request)
        {
            var user = new User
            {
                Login = request.Login,
                Password = HashPassword(request.Password),
                Role = request.Role,
                SchoolId = request.SchoolId
            };

            var createdUser = await _userRepository.CreateAsync(user);
            return MapToResponse(createdUser);
        }

        /// <inheritdoc/>
        public async Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest request)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with ID {id} not found.");

            existingUser.Login = request.Login;
            existingUser.Role = request.Role;
            existingUser.CurrentLessonId = request.CurrentLessonId;
            existingUser.SchoolId = request.SchoolId;

            if (!string.IsNullOrEmpty(request.Password))
            {
                existingUser.Password = HashPassword(request.Password);
            }

            var updatedUser = await _userRepository.UpdateAsync(existingUser);
            return MapToResponse(updatedUser);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task<bool> VerifyPasswordAsync(User user, string password)
        {
            var hashedPassword = HashPassword(password);
            return user.Password == hashedPassword;
        }

        /// <summary>
        /// Maps a user entity to a user response model.
        /// </summary>
        /// <param name="user">The user entity to map.</param>
        /// <returns>The mapped user response model.</returns>
        private static UserResponse MapToResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Login = user.Login,
                Role = user.Role,
                CurrentLessonId = user.CurrentLessonId,
                SchoolId = user.SchoolId,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        /// <summary>
        /// Securely hashes a password using SHA256 algorithm.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <returns>A base64 encoded string representing the hashed password.</returns>
        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user to generate the token for.</param>
        /// <returns>A JWT token string.</returns>
        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("SchoolId", user.SchoolId.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
} 