using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories.Abstractions
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudentById(int studentId);
        Task<int> CreateStudent(Student student);
        Task<int> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int studentId);
        Task<IEnumerable<Course>> GetCoursesByStudentId(int studentId);
    }
}