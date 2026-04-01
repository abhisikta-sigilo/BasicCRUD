using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentResponseDto>> GetStudents();
        Task<StudentResponseDto?> GetStudentById(int id);
        Task<StudentResponseDto> CreateStudent(CreateStudentDto createDto);
        Task<bool> UpdateStudent(int id, UpdateStudentDto updateDto);
        Task<bool> DeleteStudent(int id);
        Task<IEnumerable<CourseResponseDto>> GetCoursesByStudentId(int id);
    }
}
