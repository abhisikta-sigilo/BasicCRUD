using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course?> GetCourseById(int id);
        Task<int> CreateCourse(Course course); // returns created course id
        Task<int> UpdateCourse(Course course); // returns rows affected
        Task<bool> DeleteCourse(int id); // returns true if deleted
    }
}