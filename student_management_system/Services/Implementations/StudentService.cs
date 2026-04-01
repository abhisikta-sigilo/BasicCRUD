using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task<IEnumerable<GetStudentDto>> GetStudents()
        {
            IEnumerable<Student> students = await studentRepository.GetStudents();

            IEnumerable<GetStudentDto> studentDtos = students.Select(s => new GetStudentDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            });

            return studentDtos;
        }


        public async Task<GetStudentDto?> GetStudentById(int id)
        {
            Student? student = await studentRepository.GetStudentById(id);

            if (student == null)
                return null;

            GetStudentDto studentDto = new GetStudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return studentDto;
        }


        public async Task<GetStudentDto> CreateStudent(CreateStudentDto createDto)
        {
            Student student = new Student
            {
                Name = createDto.Name,
                Email = createDto.Email
            };

            int id = await studentRepository.CreateStudent(student);

            GetStudentDto studentDto = new GetStudentDto
            {
                Id = id,
                Name = student.Name,
                Email = student.Email
            };

            return studentDto;
        }


        public async Task<bool> UpdateStudent(int id, UpdateStudentDto updateDto)
        {
            Student student = new Student
            {
                Id = id,
                Name = updateDto.Name,
                Email = updateDto.Email
            };

            int rowsAffected = await studentRepository.UpdateStudent(student);

            return rowsAffected > 0;
        }


        public async Task<bool> DeleteStudent(int id)
        {
            bool deleted = await studentRepository.DeleteStudent(id);

            return deleted;
        }


        public async Task<IEnumerable<GetCourseDto>> GetCoursesByStudentId(int id)
        {
            IEnumerable<Course> courses = await studentRepository.GetCoursesByStudentId(id);

            IEnumerable<GetCourseDto> courseDtos = courses.Select(c => new GetCourseDto
            {
                Id = c.Id,
                CourseName = c.CourseName
            });

            return courseDtos;
        }
    }
}
