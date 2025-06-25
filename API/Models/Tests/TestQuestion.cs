using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Tests
{
    public class TestQuestion
    {
        public int QuestionId { get; set; }
        public required string Question { get; set; }
        public required QuestionType QuestionType { get; set; }
        public required List<TestAnswer> Answers { get; set; }
    }

    public class TestAnswer
    {
        public int AnswerId { get; set; }
        public required string[] Text { get; set; }
    }
} 