using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController(ICourseRepository courseRepository) : ControllerBase
    {
        [HttpGet]
        // This endpoint returns a list of GetCourseDto objects
        public async Task<ActionResult<IEnumerable<GetCourseDto>>> GetAllCourses()
        {
            // get entities from database
            var courses = await courseRepository.GetAllAsync();

            // convert the entities into dtos
            var courseDtos = courses.Select(c => new GetCourseDto
            {
                Id = c.Id,
                CourseName = c.CourseName
            });
            return Ok(courseDtos);
        }


        [HttpGet("{id}")]

        // This endpoint returns one GetCourseDto object
        public async Task<ActionResult<GetCourseDto>> GetCourse(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            // to dto
            var courseDto = new GetCourseDto
            {
                Id = course.Id,
                CourseName = course.CourseName
            };

            return Ok(courseDto);
        }


        [HttpPost]
        public async Task<ActionResult<GetCourseDto>> CreateCourse(CreateCourseDto createDto)
        {
            // convert CreateCourseDto to Course Entity
            var course = new Course
            {
                CourseName = createDto.CourseName
            };

            // save course to database
            var id = await courseRepository.CreateAsync(course);

            // convert entity to GetCourseDto
            var courseDto = new GetCourseDto
            {
                Id = id,
                CourseName = course.CourseName
            };

            // return 201 created
            return CreatedAtAction(nameof(GetCourse), new { id }, courseDto);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto updateDto)
        {
            var course = new Course
            {
                Id = id,
                CourseName = updateDto.CourseName
            };

            var rows = await courseRepository.UpdateAsync(course);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await courseRepository.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}