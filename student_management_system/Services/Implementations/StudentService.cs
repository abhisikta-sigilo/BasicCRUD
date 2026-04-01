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


        public async Task<StudentResponseDto?> GetStudentById(int studentId)
        {
            Student? student = await studentRepository.GetStudentById(studentId);

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


        public async Task<bool> UpdateStudent(int studentId, UpdateStudentDto updateDto)
        {
            Student student = new Student
            {
                Id = studentId,
                Name = updateDto.Name,
                Email = updateDto.Email
            };

            int rowsAffected = await studentRepository.UpdateStudent(student);

            return rowsAffected > 0;
        }


        public async Task<bool> DeleteStudent(int studentId)
        {
            bool deleted = await studentRepository.DeleteStudent(studentId);

            return deleted;
        }


        public async Task<IEnumerable<CourseResponseDto>?> GetCoursesByStudentId(int studentId)
        {
            IEnumerable<Course> courses = await studentRepository.GetCoursesByStudentId(studentId);

            if (!courses.Any())
                return null;

            IEnumerable<CourseResponseDto> courseDtos = courses.Select(c => new CourseResponseDto
            {
                Id = c.Id,
                CourseName = c.CourseName
            });

            return courseDtos;
        }
    }
}
