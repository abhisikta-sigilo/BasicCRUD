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
        
        public async Task<ActionResult<IEnumerable<EnrollmentResponseDto>>> GetEnrollments()
        {
            // get entities from database
            IEnumerable<EnrollmentResponseDto> enrollmentDtos = await enrollmentService.GetEnrollments();

            return Ok(enrollmentDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentResponseDto>> GetEnrollmentById(int id)
        {
            EnrollmentResponseDto? enrollmentDto = await enrollmentService.GetEnrollmentById(id);

            if (enrollmentDto == null)
                return NotFound();

            return Ok(enrollmentDto);
        }


        [HttpPost]
        public async Task<ActionResult<EnrollmentResponseDto>> CreateEnrollment(CreateEnrollmentDto createDto)
        {
            EnrollmentResponseDto enrollmentDto = await enrollmentService.CreateEnrollment(createDto);

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