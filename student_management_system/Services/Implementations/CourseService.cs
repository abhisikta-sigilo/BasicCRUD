using AutoMapper;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    // services call repositories to fetch/store entities/to database
    public class CourseService(
        ICourseRepository courseRepository, 
        IMapper mapper
    ) : ICourseService
    {
        public async Task<IEnumerable<CourseResponseDto>> GetCourses()
        {
            IEnumerable<Course> courses = await courseRepository.GetCourses();

            // convert the entities into dtos
            //IEnumerable<CourseResponseDto> courseDtos = courses.Select(c => new CourseResponseDto
            //{
            //    Id = c.Id,
            //    CourseName = c.CourseName
            //});

            //return courseDtos;

            return mapper.Map<IEnumerable<CourseResponseDto>>(courses);
        }


        public async Task<CourseResponseDto?> GetCourseById(int courseId)
        {
            Course? course = await courseRepository.GetCourseById(courseId);

            if (course == null)
                return null;

            // to dto
            //CourseResponseDto courseDto = new CourseResponseDto
            //{
            //    Id = course.Id,
            //    CourseName = course.CourseName
            //};

            //return courseDto; new CourseResponseDto
            //{
            //    Id = course.Id,
            //    CourseName = course.CourseName
            //};

            //return courseDto;

            return mapper.Map<CourseResponseDto>(course);
        }


        public async Task<CourseResponseDto> CreateCourse(CreateCourseDto createDto)
        {
            // convert CreateCourseDto to Course Entity
            Course course = mapper.Map<Course>(createDto);

            // save course to database
            int id = await courseRepository.CreateCourse(course);

            // convert entity to CourseResponseDto
            CourseResponseDto courseDto = mapper.Map<CourseResponseDto>(course);
            courseDto.Id = id;

            return courseDto;
        }


        public async Task<bool> UpdateCourse(int courseId, UpdateCourseDto updateDto)
        {
            Course course = mapper.Map<Course>(updateDto);
            course.Id = courseId;

            int rows = await courseRepository.UpdateCourse(course);

            return rows > 0;
        }


        public async Task<bool> DeleteCourse(int courseId)
        {
            bool deleted = await courseRepository.DeleteCourse(courseId);

            return deleted;
        }


        public async Task<IEnumerable<StudentResponseDto>?> GetStudentsByCourseId(int courseId)
        {
            IEnumerable<Student> students = await courseRepository.GetStudentsByCourseId(courseId);

            if (!students.Any())
                return null;

            return mapper.Map<IEnumerable<StudentResponseDto>>(students);
        }
    }
}
