using Database.Models;

namespace Database.Repositories
{
    /// <summary>
    /// Interface for managing Answer entities in the database
    /// </summary>
    public interface IAnswerRepository
    {
        /// <summary>
        /// Gets all answers from the database
        /// </summary>
        /// <returns>A collection of all answers</returns>
        Task<IEnumerable<Answer>> GetAllAsync();

        /// <summary>
        /// Gets an answer by its ID
        /// </summary>
        /// <param name="id">The ID of the answer to retrieve</param>
        /// <returns>The answer if found, null otherwise</returns>
        Task<Answer?> GetByIdAsync(int id);

        /// <summary>
        /// Gets all answers for a specific question
        /// </summary>
        /// <param name="questionId">The ID of the question</param>
        /// <returns>A collection of answers for the specified question</returns>
        Task<IEnumerable<Answer>> GetByQuestionIdAsync(int questionId);

        /// <summary>
        /// Creates a new answer in the database
        /// </summary>
        /// <param name="answer">The answer entity to create</param>
        /// <returns>The created answer with updated ID</returns>
        Task<Answer> CreateAsync(Answer answer);

        /// <summary>
        /// Updates an existing answer in the database
        /// </summary>
        /// <param name="answer">The answer entity with updated data</param>
        /// <returns>The updated answer</returns>
        Task<Answer> UpdateAsync(Answer answer);

        /// <summary>
        /// Deletes an answer from the database
        /// </summary>
        /// <param name="id">The ID of the answer to delete</param>
        /// <returns>True if the answer was deleted, false if not found</returns>
        Task<bool> DeleteAsync(int id);
    }
} 