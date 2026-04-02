using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services.Abstractions;
using StudentManagementSystem.Services.Implementations;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController(ICourseService courseService) : ControllerBase
    {
        [HttpGet]
        // This endpoint returns a list of CourseResponseDto objects
        public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetCourses()
        {
            IEnumerable<CourseResponseDto> courses = await courseService.GetCourses();

            return Ok(courses);
        }


        [HttpGet("{courseId}", Name = "GetCourseById")]
        public async Task<ActionResult<CourseResponseDto>> GetCourseById(int courseId)
        {
            CourseResponseDto? course = await courseService.GetCourseById(courseId);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }


        [HttpPost]
        public async Task<ActionResult<CourseResponseDto>> CreateCourse(CreateCourseDto createDto)
        {
            CourseResponseDto courseDto = await courseService.CreateCourse(createDto);

            // return 201 created
            return CreatedAtRoute(
                "GetCourseById", 
                new { courseId = courseDto.Id }, 
                courseDto);
        }


        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateCourse(int courseId, UpdateCourseDto updateDto)
        {
            bool updated = await courseService.UpdateCourse(courseId, updateDto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            bool deleted = await courseService.DeleteCourse(courseId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpGet("{courseId}/students")]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetStudentsByCourseId(int courseId)
        {
            IEnumerable<StudentResponseDto>? students = await courseService.GetStudentsByCourseId(courseId);

            if (students == null)
                return NotFound();

            return Ok(students);
        }
    }
}