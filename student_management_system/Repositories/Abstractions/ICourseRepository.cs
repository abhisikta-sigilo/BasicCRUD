using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories.Abstractions
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourseById(int courseId);
        Task<int> CreateCourse(Course course); // returns created course id
        Task<int> UpdateCourse(Course course); // returns rows affected
        Task<bool> DeleteCourse(int courseId); // returns true if deleted
        Task<IEnumerable<Student>> GetStudentsByCourseId(int courseId);
    }
}