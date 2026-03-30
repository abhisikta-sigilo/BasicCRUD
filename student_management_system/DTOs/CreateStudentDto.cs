using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}