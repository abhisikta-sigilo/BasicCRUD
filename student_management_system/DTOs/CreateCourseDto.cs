using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class CreateCourseDto
    {
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
    }
}