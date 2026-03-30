using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(IStudentRepository studentRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> GetAll()
        {
            var students = await studentRepository.GetAllAsync();

            var studentDtos = students.Select(s => new GetStudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            });

            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> GetById(int id)
        {
            var student = await studentRepository.GetByIdAsync(id);

            if (student == null)
                return NotFound();

            var studentDto = new GetStudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult<GetStudentDto>> Create(CreateStudentDto createDto)
        {
            var student = new Student
            {
                Name = createDto.Name,
                Email = createDto.Email
            };

            var id = await studentRepository.CreateAsync(student);

            var studentDto = new GetStudentDto
            {
                Id = id,
                Name = student.Name,
                Email = student.Email
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id },
                studentDto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto updateDto)
        {
            var student = new Student
            {
                Id = id,
                Name = updateDto.Name,
                Email = updateDto.Email
            };

            var rowsAffected = await studentRepository.UpdateAsync(student);

            if (rowsAffected == 0)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await studentRepository.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}