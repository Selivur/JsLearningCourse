using System.ComponentModel.DataAnnotations;
using Database.Models;

namespace API.Models.Question
{
    /// <summary>
    /// Request model for checking student's answers.
    /// </summary>
    public class CheckAnswersRequest
    {
        /// <summary>
        /// Collection of answers to check.
        /// </summary>
        [Required]
        public List<AnswerToCheck> Answers { get; set; }
    }

    /// <summary>
    /// Model representing a single answer to check.
    /// </summary>
    public class AnswerToCheck
    {
        /// <summary>
        /// The type of the question.
        /// </summary>
        [Required]
        public QuestionType Type { get; set; }

        /// <summary>
        /// The ID of the answer (for regular and multiple choice questions) or array of answer IDs (for multiple choice questions).
        /// </summary>
        public List<int>? AnswerIds { get; set; }

        /// <summary>
        /// The text answer (for open-ended questions).
        /// </summary>
        public string? AnswerText { get; set; }
    }
} 