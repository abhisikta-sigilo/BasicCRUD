using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Repositories.Implementations;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    // services call repositories to fetch/store entities/to database
    public class CourseService(ICourseRepository courseRepository) : ICourseService
    {
        public async Task<IEnumerable<CourseResponseDto>> GetCourses()
        {
            IEnumerable<Course> courses = await courseRepository.GetCourses();

            // convert the entities into dtos
            IEnumerable<CourseResponseDto> courseDtos = courses.Select(c => new CourseResponseDto
            {
                Id = c.Id,
                CourseName = c.CourseName
            });

            return courseDtos;
        }


        public async Task<CourseResponseDto?> GetCourseById(int id)
        {
            Course? course = await courseRepository.GetCourseById(id);

            if (course == null)
                return null;

            // to dto
            CourseResponseDto courseDto = new CourseResponseDto
            {
                Id = course.Id,
                CourseName = course.CourseName
            };

            return courseDto;
        }


        public async Task<CourseResponseDto> CreateCourse(CreateCourseDto createDto)
        {
            // convert CreateCourseDto to Course Entity
            Course course = new Course
            {
                CourseName = createDto.CourseName
            };

            // save course to database
            int id = await courseRepository.CreateCourse(course);

            // convert entity to CourseResponseDto
            CourseResponseDto courseDto = new CourseResponseDto
            {
                Id = id,
                CourseName = course.CourseName
            };
            return courseDto;
        }


        public async Task<bool> UpdateCourse(int id, UpdateCourseDto updateDto)
        {
            Course course = new Course
            {
                Id = id,
                CourseName = updateDto.CourseName
            };

            int rows = await courseRepository.UpdateCourse(course);

            return rows > 0;
        }


        public async Task<bool> DeleteCourse(int id)
        {
            bool deleted = await courseRepository.DeleteCourse(id);

            return deleted;
        }


        public async Task<IEnumerable<StudentResponseDto>> GetStudentsByCourseId(int id)
        {
            IEnumerable<Student> students = await courseRepository.GetStudentsByCourseId(id);

            IEnumerable<StudentResponseDto> studentDtos = students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            });

            return studentDtos;
        }
    }
}
