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


        [HttpGet("{enrollmentId}", Name = "GetEnrollmentById")]
        public async Task<ActionResult<EnrollmentResponseDto>> GetEnrollmentById(int enrollmentId)
        {
            EnrollmentResponseDto? enrollmentDto = await enrollmentService.GetEnrollmentById(enrollmentId);

            if (enrollmentDto == null)
                return NotFound();

            return Ok(enrollmentDto);
        }


        [HttpPost]
        public async Task<ActionResult<EnrollmentResponseDto>> CreateEnrollment(CreateEnrollmentDto createDto)
        {
            EnrollmentResponseDto enrollmentDto = await enrollmentService.CreateEnrollment(createDto);

            return CreatedAtRoute(
                "GetEnrollmentById",
                new { enrollmentId = enrollmentDto.Id },
                enrollmentDto
            );
        }

        [HttpPut("{enrollmentId}")]
        public async Task<IActionResult> UpdateEnrollment(int enrollmentId, UpdateEnrollmentDto updateDto)
        {
            bool updated = await enrollmentService.UpdateEnrollment(enrollmentId, updateDto);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{enrollmentId}")]
        public async Task<IActionResult> DeleteEnrollment(int enrollmentId)
        {
            bool deleted = await enrollmentService.DeleteEnrollment(enrollmentId);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}