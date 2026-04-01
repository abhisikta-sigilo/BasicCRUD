using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Services.Abstractions
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponseDto>> GetCourses();
        Task<CourseResponseDto?> GetCourseById(int courseId);
        Task<CourseResponseDto> CreateCourse(CreateCourseDto createDto);
        Task<bool> UpdateCourse(int courseId, UpdateCourseDto updateDto); // returning bool to see if the operation succeeded
        Task<bool> DeleteCourse(int courseId);
        Task<IEnumerable<StudentResponseDto>?> GetStudentsByCourseId(int courseId);
    }
}