using Database.Models;

namespace Database.Repositories
{
    /// <summary>
    /// Interface for managing Question entities in the database
    /// </summary>
    public interface IQuestionRepository
    {
        /// <summary>
        /// Gets all questions from the database
        /// </summary>
        /// <returns>A collection of all questions</returns>
        Task<IEnumerable<Question>> GetAllAsync();

        /// <summary>
        /// Gets a question by its ID
        /// </summary>
        /// <param name="id">The ID of the question to retrieve</param>
        /// <returns>The question if found, null otherwise</returns>
        Task<Question?> GetByIdAsync(int id);

        /// <summary>
        /// Gets all questions for a specific lesson
        /// </summary>
        /// <param name="lessonId">The ID of the lesson</param>
        /// <returns>A collection of questions for the specified lesson</returns>
        Task<IEnumerable<Question>> GetByLessonIdAsync(double lessonId);

        /// <summary>
        /// Gets all questions for a specific school
        /// </summary>
        /// <param name="schoolId">The ID of the school</param>
        /// <returns>A collection of questions for the specified school</returns>
        Task<IEnumerable<Question>> GetBySchoolIdAsync(int schoolId);

        /// <summary>
        /// Creates a new question in the database
        /// </summary>
        /// <param name="question">The question entity to create</param>
        /// <returns>The created question with updated ID</returns>
        Task<Question> CreateAsync(Question question);

        /// <summary>
        /// Updates an existing question in the database
        /// </summary>
        /// <param name="question">The question entity with updated data</param>
        /// <returns>The updated question</returns>
        Task<Question> UpdateAsync(Question question);

        /// <summary>
        /// Deletes a question from the database
        /// </summary>
        /// <param name="id">The ID of the question to delete</param>
        /// <returns>True if the question was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id);
    }
} 