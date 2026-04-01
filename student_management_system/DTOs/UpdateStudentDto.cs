using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class UpdateStudentDto
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}