using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories.Abstractions
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudentById(int id);
        Task<int> CreateStudent(Student student);
        Task<int> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);
    }
}