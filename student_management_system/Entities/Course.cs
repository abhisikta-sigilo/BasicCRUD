using StudentManagementSystem.Models;

namespace StudentManagementSystem.Models;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; }

    public List<Enrollment> Enrollments { get; set; }
}