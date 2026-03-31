using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    // services call repositories to fetch/store entities/to database
    public class CourseService(ICourseRepository courseRepository) : ICourseService
    {
        public async Task<IEnumerable<GetCourseDto>> GetAllCourses()
        {
            IEnumerable<Course> courses = await courseRepository.GetAllCourses();

            // convert the entities into dtos
            IEnumerable<GetCourseDto> courseDtos = courses.Select(c => new GetCourseDto
            {
                Id = c.Id,
                CourseName = c.CourseName
            });

            return courseDtos;
        }


        public async Task<GetCourseDto?> GetCourseById(int id)
        {
            Course? course = await courseRepository.GetCourseById(id);

            if (course == null)
                return null;

            // to dto
            GetCourseDto courseDto = new GetCourseDto
            {
                Id = course.Id,
                CourseName = course.CourseName
            };

            return courseDto;
        }


        public async Task<GetCourseDto> CreateCourse(CreateCourseDto createDto)
        {
            // convert CreateCourseDto to Course Entity
            Course course = new Course
            {
                CourseName = createDto.CourseName
            };

            // save course to database
            int id = await courseRepository.CreateCourse(course);

            // convert entity to GetCourseDto
            GetCourseDto courseDto = new GetCourseDto
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
    }
}
