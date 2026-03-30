using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class CreateEnrollmentDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Range(0, 100)]
        public int Percentage { get; set; }
    }
}