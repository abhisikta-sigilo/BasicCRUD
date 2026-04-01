using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentResponseDto>> GetEnrollments();
        Task<EnrollmentResponseDto?> GetEnrollmentById(int enrollmentId);
        Task<EnrollmentResponseDto> CreateEnrollment(CreateEnrollmentDto createDto);
        Task<bool> UpdateEnrollment(int enrollmentId, UpdateEnrollmentDto updateDto);
        Task<bool> DeleteEnrollment(int enrollmentId);
    }
}
