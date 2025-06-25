using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string AnswerText { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [Required]
        public int QuestionId { get; set; }

        // Navigation property
        public virtual Question Question { get; set; }
    }
} 