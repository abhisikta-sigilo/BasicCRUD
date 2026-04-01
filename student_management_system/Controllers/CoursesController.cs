using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services.Abstractions;
using StudentManagementSystem.Services.Implementations;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        [HttpGet]
        // This endpoint returns a list of CourseResponseDto objects
        public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetCourses()
        {
            IEnumerable<CourseResponseDto> courses = await courseService.GetCourses();

            return Ok(courses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CourseResponseDto>> GetCourseById(int id)
        {
            CourseResponseDto? course = await courseService.GetCourseById(id);

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
            return CreatedAtAction(nameof(GetCourseById), new { id = courseDto.Id }, courseDto);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto updateDto)
        {
            bool updated = await courseService.UpdateCourse(id, updateDto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            bool deleted = await courseService.DeleteCourse(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpGet("{id}/students")]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetStudentsByCourseId(int id)
        {
            IEnumerable<StudentResponseDto> students = await courseService.GetStudentsByCourseId(id);

            if (!students.Any())
                return NotFound();

            return Ok(students);
        }
    }
}