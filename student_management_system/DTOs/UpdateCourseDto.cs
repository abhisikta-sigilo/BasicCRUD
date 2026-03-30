using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class UpdateCourseDto
    {
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
    }
}