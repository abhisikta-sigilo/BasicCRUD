using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController(IEnrollmentRepository enrollmentRepository) : ControllerBase
    {
        [HttpGet]
        // This endpoint returns a list of GetCourseDto objects
        public async Task<ActionResult<IEnumerable<GetEnrollmentDto>>> GetAll()
        {

            // get entities from database
            var enrollments = await enrollmentRepository.GetAllAsync();


            // get entities from database
            var enrollmentDtos = enrollments.Select(e => new GetEnrollmentDto
            {
                Id = e.Id,
                StudentId = e.StudentId,
                CourseId = e.CourseId,
                Percentage = e.Percentage
            });

            return Ok(enrollmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEnrollmentDto>> GetById(int id)
        {
            var enrollment = await enrollmentRepository.GetByIdAsync(id);

            if (enrollment == null)
                return NotFound();

            var enrollmentDto = new GetEnrollmentDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                Percentage = enrollment.Percentage
            };

            return Ok(enrollmentDto);
        }

        [HttpPost]
        public async Task<ActionResult<GetEnrollmentDto>> Create(CreateEnrollmentDto createDto)
        {

            // convert CreateEnrollmentDto to Enrollment Entity
            var enrollment = new Enrollment
            {
                StudentId = createDto.StudentId,
                CourseId = createDto.CourseId,
                Percentage = createDto.Percentage
            };

            // save course to database
            var id = await enrollmentRepository.CreateAsync(enrollment);


            // convert entity to GetEnrollmentDto
            var enrollmentDto = new GetEnrollmentDto
            {
                Id = id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                Percentage = enrollment.Percentage
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                enrollmentDto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEnrollmentDto updateDto)
        {
            var enrollment = new Enrollment
            {
                Id = id,
                StudentId = updateDto.StudentId,
                CourseId = updateDto.CourseId,
                Percentage = updateDto.Percentage
            };

            var rows = await enrollmentRepository.UpdateAsync(enrollment);

            if (rows == 0)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await enrollmentRepository.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}