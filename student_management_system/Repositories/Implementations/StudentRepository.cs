using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using System.Data;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class StudentRepository(DapperContext context) : IStudentRepository
    {
        public async Task<IEnumerable<Student>> GetStudents()
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "SELECT * FROM Students";

            IEnumerable<Student> students = await connection.QueryAsync<Student>(query);

            return students.ToList();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "SELECT * FROM Students WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Student>(query, new { Id = id });
        }

        public async Task<int> CreateStudent(Student student)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"INSERT INTO Students (Name, Email)
                          VALUES (@Name, @Email);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

            int id = await connection.ExecuteScalarAsync<int>(query, student);

            return id;
        }

        public async Task<int> UpdateStudent(Student student)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"UPDATE Students
                            SET Name = @Name,
                                Email = @Email
                            WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(query, student);

            return rowsAffected;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "DELETE FROM Students WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudentId(int id)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"SELECT c.Id, c.CourseName
                            FROM Courses c
                            INNER JOIN Enrollments e ON c.Id = e.CourseId
                            WHERE e.StudentId = @Id";

            IEnumerable<Course> courses = await connection.QueryAsync<Course>(query, new { Id = id });

            return courses.ToList();
        }
    }
}