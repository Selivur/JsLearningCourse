using Database.Models;

namespace API.Models.Question
{
    /// <summary>
    /// Response model for questions that excludes sensitive information like correct answers.
    /// </summary>
    public class QuestionResponse
    {
        /// <summary>
        /// The unique identifier of the question.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text of the question.
        /// </summary>
        public string QuestionText { get; set; }

        /// <summary>
        /// The type of the question.
        /// </summary>
        public QuestionType Type { get; set; }

        /// <summary>
        /// The ID of the lesson this question belongs to.
        /// </summary>
        public double LessonId { get; set; }

        /// <summary>
        /// The ID of the school this question belongs to.
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// Collection of possible answers for this question (without IsCorrect property).
        /// </summary>
        public List<AnswerResponse> Answers { get; set; }
    }

    /// <summary>
    /// Response model for answers that excludes the IsCorrect property.
    /// </summary>
    public class AnswerResponse
    {
        /// <summary>
        /// The unique identifier of the answer.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text of the answer.
        /// </summary>
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; } 
    }
} 