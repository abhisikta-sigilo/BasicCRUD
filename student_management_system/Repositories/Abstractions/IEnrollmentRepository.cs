using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories.Abstractions
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetEnrollments();
        Task<Enrollment?> GetEnrollmentById(int id);
        Task<int> CreateEnrollment(Enrollment enrollment);
        Task<int> UpdateEnrollment(Enrollment enrollment);
        Task<bool> DeleteEnrollment(int id);
    }
}