using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task<IEnumerable<StudentResponseDto>> GetStudents()
        {
            IEnumerable<Student> students = await studentRepository.GetStudents();

            IEnumerable<StudentResponseDto> studentDtos = students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email
            });

            return studentDtos;
        }


        public async Task<StudentResponseDto?> GetStudentById(int id)
        {
            Student? student = await studentRepository.GetStudentById(id);

            if (student == null)
                return null;

            StudentResponseDto studentDto = new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email
            };

            return studentDto;
        }


        public async Task<StudentResponseDto> CreateStudent(CreateStudentDto createDto)
        {
            Student student = new Student
            {
                Name = createDto.Name,
                Email = createDto.Email
            };

            int id = await studentRepository.CreateStudent(student);

            StudentResponseDto studentDto = new StudentResponseDto
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


        public async Task<IEnumerable<CourseResponseDto>> GetCoursesByStudentId(int id)
        {
            IEnumerable<Course> courses = await studentRepository.GetCoursesByStudentId(id);

            IEnumerable<CourseResponseDto> courseDtos = courses.Select(c => new CourseResponseDto
            {
                Id = c.Id,
                CourseName = c.CourseName
            });

            return courseDtos;
        }
    }
}
