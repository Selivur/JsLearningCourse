using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    /// <summary>
    /// Implementation of the <see cref="IQuestionRepository"/> interface.
    /// Provides data access operations for question entities in the database.
    /// </summary>
    public class QuestionRepository : IQuestionRepository
    {
        private readonly DataContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for question operations.</param>
        public QuestionRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Question?> GetByIdAsync(int id)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Question>> GetByLessonIdAsync(double lessonId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .Where(q => q.LessonId == lessonId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Question>> GetBySchoolIdAsync(int schoolId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .Where(q => q.SchoolId == schoolId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Question> CreateAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        /// <inheritdoc/>
        public async Task<Question> UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
                return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 