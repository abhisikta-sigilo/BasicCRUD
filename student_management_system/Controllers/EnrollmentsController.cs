using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController(IEnrollmentService enrollmentService) : ControllerBase
    {
        [HttpGet]
        // This endpoint returns a list of GetCourseDto objects
        public async Task<ActionResult<IEnumerable<GetEnrollmentDto>>> GetAllEnrollments()
        {
            // get entities from database
            IEnumerable<GetEnrollmentDto> enrollmentDtos = await enrollmentService.GetAllEnrollments();

            return Ok(enrollmentDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetEnrollmentDto>> GetEnrollmentById(int id)
        {
            GetEnrollmentDto? enrollmentDto = await enrollmentService.GetEnrollmentById(id);

            if (enrollmentDto == null)
                return NotFound();

            return Ok(enrollmentDto);
        }


        [HttpPost]
        public async Task<ActionResult<GetEnrollmentDto>> CreateEnrollment(CreateEnrollmentDto createDto)
        {
            GetEnrollmentDto enrollmentDto = await enrollmentService.CreateEnrollment(createDto);

            return CreatedAtAction(
                nameof(GetEnrollmentById),
                new { id = enrollmentDto.Id },
                enrollmentDto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, UpdateEnrollmentDto updateDto)
        {
            bool updated = await enrollmentService.UpdateEnrollment(id, updateDto);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            bool deleted = await enrollmentService.DeleteEnrollment(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}