using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(IStudentService studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResponseDto>>> GetStudents()
        {
            IEnumerable<StudentResponseDto> studentsDtos = await studentService.GetStudents();

            return Ok(studentsDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDto>> GetStudentById(int id)
        {
            StudentResponseDto? student = await studentService.GetStudentById(id);

            if (student == null)
                return NotFound();
            
            return Ok(student);
        }


        [HttpPost]
        public async Task<ActionResult<StudentResponseDto>> CreateStudent(CreateStudentDto createDto)
        {
            StudentResponseDto studentDto = await studentService.CreateStudent(createDto);

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
            bool deleted = await studentService.DeleteStudent(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }


        [HttpGet("{id}/courses")]
        public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetCoursesByStudentId(int id)
        {
            IEnumerable<CourseResponseDto> courses = await studentService.GetCoursesByStudentId(id);

            if (!courses.Any())
                return NotFound();

            return Ok(courses);
        }
    }
}