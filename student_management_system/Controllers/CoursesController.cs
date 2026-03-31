using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        [HttpGet]
        // This endpoint returns a list of GetCourseDto objects
        public async Task<ActionResult<IEnumerable<GetCourseDto>>> GetAllCourses()
        {
            IEnumerable<GetCourseDto> courses = await courseService.GetAllCourses();

            return Ok(courses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetCourseDto>> GetCourseById(int id)
        {
            GetCourseDto? course = await courseService.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }


        [HttpPost]
        public async Task<ActionResult<GetCourseDto>> CreateCourse(CreateCourseDto createDto)
        {
            GetCourseDto courseDto = await courseService.CreateCourse(createDto);

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

    }
}