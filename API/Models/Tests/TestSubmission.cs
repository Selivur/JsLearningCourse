using Database.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Tests
{
    public class TestSubmission
    {
        public int QuestionId { get; set; }
        public QuestionType QuestionType { get; set; }
        public required object Answer { get; set; } // int[] для вибору, string для тексту
    }
} 