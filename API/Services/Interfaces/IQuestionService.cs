using API.Models.Question;
using Database.Models;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Interface for managing question-related operations.
    /// Defines methods for question creation and retrieval.
    /// </summary>
    public interface IQuestionService
    {
        /// <summary>
        /// Creates a new question with its answers in the system.
        /// </summary>
        /// <param name="request">The question creation request model containing question text, type, and answers.</param>
        /// <returns>The created question response model.</returns>
        Task<QuestionResponse> CreateQuestionAsync(CreateQuestionRequest request);

        /// <summary>
        /// Updates an existing question with its answers.
        /// </summary>
        /// <param name="request">The question update request model containing the ID and updated data.</param>
        /// <returns>The updated question response model.</returns>
        Task<QuestionResponse> UpdateQuestionAsync(CreateQuestionRequest request);

        /// <summary>
        /// Retrieves all questions for a specific lesson and school without exposing correct answers.
        /// </summary>
        /// <param name="lessonId">The unique identifier of the lesson.</param>
        /// <param name="schoolId">The unique identifier of the school.</param>
        /// <returns>A collection of question response models without correct answers.</returns>
        Task<IEnumerable<QuestionResponse>> GetQuestionsByLessonAndSchoolIdAsync(double lessonId, int schoolId);

        /// <summary>
        /// Checks student's answers and calculates the score.
        /// </summary>
        /// <param name="request">The request containing answers to check.</param>
        /// <returns>The number of correct answers.</returns>
        Task<int> CheckAnswersAsync(CheckAnswersRequest request);

        /// <summary>
        /// Deletes all questions for a specific lesson and school.
        /// </summary>
        /// <param name="lessonId">The unique identifier of the lesson.</param>
        /// <param name="schoolId">The unique identifier of the school.</param>
        /// <returns>True if the operation was successful.</returns>
        Task<bool> DeleteQuestionsByLessonAndSchoolIdAsync(double lessonId, int schoolId);
    }
} 