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
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> GetAllStudents()
        {
            var students = await studentRepository.GetAllStudents();

            var studentDtos = students.Select(s => new GetStudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            });

            return Ok(studentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudentById(int id)
        {
            var student = await studentRepository.GetStudentById(id);

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
        public async Task<ActionResult<GetStudentDto>> CreateStudent(CreateStudentDto createDto)
        {
            var student = new Student
            {
                Name = createDto.Name,
                Email = createDto.Email
            };

            var id = await studentRepository.CreateStudent(student);

            var studentDto = new GetStudentDto
            {
                Id = id,
                Name = student.Name,
                Email = student.Email
            };

            return CreatedAtAction(
                nameof(GetStudentById),
                new { id },
                studentDto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto updateDto)
        {
            var student = new Student
            {
                Id = id,
                Name = updateDto.Name,
                Email = updateDto.Email
            };

            var rowsAffected = await studentRepository.UpdateStudent(student);

            if (rowsAffected == 0)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await studentRepository.DeleteStudent(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}