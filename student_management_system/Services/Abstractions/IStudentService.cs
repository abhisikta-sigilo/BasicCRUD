using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface IStudentService
    {
        Task<IEnumerable<GetStudentDto>> GetAllStudents();
        Task<GetStudentDto?> GetStudentById(int id);
        Task<GetStudentDto> CreateStudent(CreateStudentDto createDto);
        Task<bool> UpdateStudent(int id, UpdateStudentDto updateDto);
        Task<bool> DeleteStudent(int id);
    }
}
