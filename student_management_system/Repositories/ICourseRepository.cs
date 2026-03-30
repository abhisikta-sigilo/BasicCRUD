using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync();
        Task<Course?> GetByIdAsync(int id);
        Task<int> CreateAsync(Course course); // returns created course id
        Task<int> UpdateAsync(Course course); // returns rows affected
        Task<bool> DeleteAsync(int id); // returns true if deleted
    }
}