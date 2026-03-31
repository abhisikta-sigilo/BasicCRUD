using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(IStudentService studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetStudentDto>>> GetAllStudents()
        {
            var studentsDtos = await studentService.GetAllStudents();

            return Ok(studentsDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetStudentDto>> GetStudentById(int id)
        {
            var student = await studentService.GetStudentById(id);

            if (student == null)
                return NotFound();
            
            return Ok(student);
        }


        [HttpPost]
        public async Task<ActionResult<GetStudentDto>> CreateStudent(CreateStudentDto createDto)
        {
            var studentDto = await studentService.CreateStudent(createDto);

            return CreatedAtAction(
                nameof(GetStudentById),
                new { id = studentDto.Id },
                studentDto
            );
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto updateDto)
        {
            bool updated = await studentService.UpdateStudent(id, updateDto);

            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await studentService.DeleteStudent(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}