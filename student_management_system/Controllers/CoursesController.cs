using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

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
            var courses = await courseService.GetAllCourses();

            return Ok(courses);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetCourseDto>> GetCourseById(int id)
        {
            var course = await courseService.GetCourseById(id);

            return Ok(course);
        }


        [HttpPost]
        public async Task<ActionResult<GetCourseDto>> CreateCourse(CreateCourseDto createDto)
        {

            var courseDto = await courseService.CreateCourse(createDto);

            // return 201 created
            return CreatedAtAction(nameof(GetCourseById), new { id = courseDto.Id }, courseDto);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto updateDto)
        {
            var updated = await courseService.UpdateCourse(id, updateDto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await courseService.DeleteCourse(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}