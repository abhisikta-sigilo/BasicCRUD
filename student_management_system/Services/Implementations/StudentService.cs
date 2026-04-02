using AutoMapper;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    public class StudentService(
        IStudentRepository studentRepository,
        IMapper mapper
    ) : IStudentService
    {
        public async Task<IEnumerable<StudentResponseDto>> GetStudents()
        {
            IEnumerable<Student> students = await studentRepository.GetStudents();

            return mapper.Map<IEnumerable<StudentResponseDto>>(students);
        }


        public async Task<StudentResponseDto?> GetStudentById(int studentId)
        {
            Student? student = await studentRepository.GetStudentById(studentId);

            if (student == null)
                return null;

            return mapper.Map<StudentResponseDto>(student);
        }


        public async Task<StudentResponseDto> CreateStudent(CreateStudentDto createDto)
        {
            // DTO -> Entity
            Student student = mapper.Map<Student>(createDto);

            int id = await studentRepository.CreateStudent(student);

            // Entity -> DTO
            StudentResponseDto studentDto = mapper.Map<StudentResponseDto>(student);
            studentDto.Id = id;

            return studentDto;
        }


        public async Task<bool> UpdateStudent(int studentId, UpdateStudentDto updateDto)
        {
            Student student = mapper.Map<Student>(updateDto);
            student.Id = studentId;

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

            return mapper.Map<IEnumerable<CourseResponseDto>>(courses);
        }
    }
}
