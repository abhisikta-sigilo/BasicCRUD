using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class StudentRepository(DapperContext context) : IStudentRepository
    {
        public async Task<List<Student>> GetAllStudents()
        {
            using var connection = context.CreateConnection();

            var students = await connection
                .QueryAsync<Student>("SELECT * FROM Students");

            return students.ToList();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            using var connection = context.CreateConnection();

            var student = await connection
                .QueryFirstOrDefaultAsync<Student>(
                    "SELECT * FROM Students WHERE Id = @Id",
                    new { Id = id });

            return student;
        }

        public async Task<int> CreateStudent(Student student)
        {
            using var connection = context.CreateConnection();

            var query = @"INSERT INTO Students (Name, Email)
                          VALUES (@Name, @Email);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

            var id = await connection.ExecuteScalarAsync<int>(query, student);

            return id;
        }

        public async Task<int> UpdateStudent(Student student)
        {
            using var connection = context.CreateConnection();

            var query = @"UPDATE Students
                          SET Name = @Name,
                              Email = @Email
                          WHERE Id = @Id";

            var rowsAffected = await connection.ExecuteAsync(query, student);

            return rowsAffected;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            using var connection = context.CreateConnection();

            var rowsAffected = await connection.ExecuteAsync(
                "DELETE FROM Students WHERE Id = @Id",
                new { Id = id });

            return rowsAffected > 0;
        }
    }
}