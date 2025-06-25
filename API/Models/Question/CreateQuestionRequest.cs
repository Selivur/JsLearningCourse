using System.ComponentModel.DataAnnotations;
using Database.Models;

namespace API.Models.Question
{
    /// <summary>
    /// Request model for creating a new question with its answers.
    /// </summary>
    public class CreateQuestionRequest
    {
        /// <summary>
        /// The ID of the question. If null, a new question will be created.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// The text of the question.
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string QuestionText { get; set; }

        /// <summary>
        /// The type of the question (Regular, MultipleChoice, or OpenEnded).
        /// </summary>
        [Required]
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
        /// Collection of possible answers for this question.
        /// </summary>
        [Required]
        public List<CreateAnswerRequest> Answers { get; set; }
    }

    /// <summary>
    /// Request model for creating a new answer.
    /// </summary>
    public class CreateAnswerRequest
    {
        /// <summary>
        /// The text of the answer.
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string AnswerText { get; set; }

        /// <summary>
        /// Indicates whether this answer is correct.
        /// </summary>
        [Required]
        public bool IsCorrect { get; set; }
    }
} 