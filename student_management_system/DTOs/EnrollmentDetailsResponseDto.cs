using StudentManagementSystem.Models;

namespace StudentManagementSystem.DTOs
{
    public class EnrollmentDetailsResponseDto
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = new();
        public Course Course { get; set; } = new();
        public int Percentage { get; set; }
    }
}