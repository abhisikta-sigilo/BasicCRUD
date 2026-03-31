using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface ICourseService
    {
        Task<IEnumerable<GetCourseDto>> GetCourses();
        Task<GetCourseDto?> GetCourseById(int id);
        Task<GetCourseDto> CreateCourse(CreateCourseDto createDto);
        Task<bool> UpdateCourse(int id, UpdateCourseDto updateDto); // returning bool to see if the operation succeeded
        Task<bool> DeleteCourse(int id);
    }
}