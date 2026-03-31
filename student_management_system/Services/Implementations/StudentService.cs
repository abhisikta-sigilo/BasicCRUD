using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task<IEnumerable<GetStudentDto>> GetAllStudents()
        {
            var students = await studentRepository.GetAllStudents();

            var studentDtos = students.Select(s => new GetStudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            });

            return studentDtos;
        }


        public async Task<GetStudentDto?> GetStudentById(int id)
        {
            var student = await studentRepository.GetStudentById(id);

            if (student == null)
                return null;

            var studentDto = new GetStudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return studentDto;
        }


        public async Task<GetStudentDto> CreateStudent(CreateStudentDto createDto)
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

            return studentDto;
        }


        public async Task<bool> UpdateStudent(int id, UpdateStudentDto updateDto)
        {
            var student = new Student
            {
                Id = id,
                Name = updateDto.Name,
                Email = updateDto.Email
            };

            var rowsAffected = await studentRepository.UpdateStudent(student);

            return rowsAffected > 0;
        }


        public async Task<bool> DeleteStudent(int id)
        {
            var deleted = await studentRepository.DeleteStudent(id);

            return deleted;
        }
    }
}
