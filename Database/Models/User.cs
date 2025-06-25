using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public required string Login { get; set; }

        public required string Password { get; set; }

        public required UserRole Role { get; set; }

        public int? CurrentLessonId { get; set; }

        public int SchoolId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(2); //todo winter time? Add user who changed
        public DateTime? UpdatedAt { get; set; }
    }
} 