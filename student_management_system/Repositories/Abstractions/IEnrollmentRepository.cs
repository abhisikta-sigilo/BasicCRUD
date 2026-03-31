using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllEnrollments();
        Task<Enrollment?> GetEnrollmentById(int id);
        Task<int> CreateEnrollment(Enrollment enrollment);
        Task<int> UpdateEnrollment(Enrollment enrollment);
        Task<bool> DeleteEnrollment(int id);
    }
}