using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class UpdateCourseDto
    {
        [Required]
        [MaxLength(100)]
        public required string CourseName { get; set; }
    }
}