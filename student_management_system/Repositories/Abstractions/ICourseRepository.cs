using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories.Abstractions
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<Course?> GetCourseById(int id);
        Task<int> CreateCourse(Course course); // returns created course id
        Task<int> UpdateCourse(Course course); // returns rows affected
        Task<bool> DeleteCourse(int id); // returns true if deleted
    }
}