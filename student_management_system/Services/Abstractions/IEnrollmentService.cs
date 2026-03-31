using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<GetEnrollmentDto>> GetAllEnrollments();
        Task<GetEnrollmentDto?> GetEnrollmentById(int id);
        Task<GetEnrollmentDto> CreateEnrollment(CreateEnrollmentDto createDto);
        Task<bool> UpdateEnrollment(int id, UpdateEnrollmentDto updateDto);
        Task<bool> DeleteEnrollment(int id);
    }
}
