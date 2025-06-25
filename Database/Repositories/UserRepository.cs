using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    /// <summary>
    /// Implementation of the <see cref="IUserRepository"/> interface.
    /// Provides data access operations for user entities in the database.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for user operations.</param>
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<User?> GetByLoginAsync(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<User>> GetStudentsBySchoolIdAsync(int schoolId)
        {
            return await _context.Users
                .Where(u => u.SchoolId == schoolId && u.Role == UserRole.Student)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<User> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <inheritdoc/>
        public async Task<User> UpdateAsync(User user)
        {
            user.UpdatedAt = DateTime.UtcNow.AddHours(2);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 