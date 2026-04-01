using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseDto>> GetStudents();
        Task<StudentResponseDto?> GetStudentById(int studentId);
        Task<StudentResponseDto> CreateStudent(CreateStudentDto createDto);
        Task<bool> UpdateStudent(int studentId, UpdateStudentDto updateDto);
        Task<bool> DeleteStudent(int studentId);
        Task<IEnumerable<CourseResponseDto>?> GetCoursesByStudentId(int studentId);
    }
}
