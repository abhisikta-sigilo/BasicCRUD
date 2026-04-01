using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentResponseDto>> GetEnrollments();
        Task<EnrollmentResponseDto?> GetEnrollmentById(int id);
        Task<EnrollmentResponseDto> CreateEnrollment(CreateEnrollmentDto createDto);
        Task<bool> UpdateEnrollment(int id, UpdateEnrollmentDto updateDto);
        Task<bool> DeleteEnrollment(int id);
    }
}
