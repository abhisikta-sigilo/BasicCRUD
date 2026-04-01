using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponseDto>> GetCourses();
        Task<CourseResponseDto?> GetCourseById(int id);
        Task<CourseResponseDto> CreateCourse(CreateCourseDto createDto);
        Task<bool> UpdateCourse(int id, UpdateCourseDto updateDto); // returning bool to see if the operation succeeded
        Task<bool> DeleteCourse(int id);
        Task<IEnumerable<StudentResponseDto>> GetStudentsByCourseId(int id);
    }
}