using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.SqlQueries;
using System.Data;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class StudentRepository(DapperContext context) : IStudentRepository
    {
        public async Task<IEnumerable<Student>> GetStudents()
        {
            using IDbConnection connection = context.CreateConnection();

            IEnumerable<Student> students = await connection.QueryAsync<Student>(StudentSqlQueries.GetStudents);

            return students.ToList();
        }

        public async Task<Student?> GetStudentById(int studentId)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Student>(
                StudentSqlQueries.GetStudentById,
                new { Id = studentId }
            );
        }

        public async Task<int> CreateStudent(Student student)
        {
            using IDbConnection connection = context.CreateConnection();

            int id = await connection.ExecuteScalarAsync<int>(
                StudentSqlQueries.CreateStudent, 
                student
            );

            return id;
        }

        public async Task<int> UpdateStudent(Student student)
        {
            using IDbConnection connection = context.CreateConnection();

            int rowsAffected = await connection.ExecuteAsync(
                StudentSqlQueries.UpdateStudent,
                student
            );

            return rowsAffected;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            using IDbConnection connection = context.CreateConnection();

            int rowsAffected = await connection.ExecuteAsync(
                StudentSqlQueries.DeleteStudent,
                new { Id = studentId }
            );

            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentId(int studentId)
        {
            using IDbConnection connection = context.CreateConnection();

            IEnumerable<Course> courses = await connection.QueryAsync<Course>(
                StudentSqlQueries.GetCoursesByStudentId,
                new { Id = studentId }
            );

            return courses.ToList();
        }
    }
}