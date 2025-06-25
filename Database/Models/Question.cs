using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string QuestionText { get; set; }

        [Required]
        public QuestionType Type { get; set; }

        [Required]
        public double LessonId { get; set; }

        [Required]
        public int SchoolId { get; set; }

        // Navigation property
        public virtual ICollection<Answer> Answers { get; set; }
    }
} 