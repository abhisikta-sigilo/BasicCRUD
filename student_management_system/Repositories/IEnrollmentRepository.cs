using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllAsync();
        Task<Enrollment?> GetByIdAsync(int id);
        Task<int> CreateAsync(Enrollment enrollment);
        Task<int> UpdateAsync(Enrollment enrollment);
        Task<bool> DeleteAsync(int id);
    }
}