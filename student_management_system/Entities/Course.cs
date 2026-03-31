using StudentManagementSystem.Models;

namespace StudentManagementSystem.Models;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; }

    public IEnumerable<Enrollment> Enrollments { get; set; }
}