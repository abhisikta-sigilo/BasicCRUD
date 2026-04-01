using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using System.Data;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class CourseRepository(DapperContext context) : ICourseRepository
    {
        public async Task<IEnumerable<Course>> GetCourses()
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "SELECT * FROM Courses";

            IEnumerable<Course> courses = await connection.QueryAsync<Course>(query);

            return courses.ToList();
        }

        public async Task<Course?> GetCourseById(int courseId)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "SELECT * FROM Courses WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Course>(query, new { Id = courseId });
        }

        public async Task<int> CreateCourse(Course course)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"INSERT INTO Courses (CourseName)
                            VALUES (@CourseName);
                            SELECT CAST(SCOPE_IDENTITY() as int);";

            return await connection.ExecuteScalarAsync<int>(query, course);
        }

        public async Task<int> UpdateCourse(Course course)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"UPDATE Courses
                            SET CourseName = @CourseName
                            WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(query, course);

            return rowsAffected;
        }

        public async Task<bool> DeleteCourse(int courseId)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "DELETE FROM Courses WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(query, new { Id = courseId });

            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Student>> GetStudentsByCourseId(int courseId)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"SELECT s.Id, s.Name, s.Email
                            FROM Students s
                            INNER JOIN Enrollments e ON s.Id = e.StudentId
                            WHERE e.CourseId = @Id";

            IEnumerable<Student> students = await connection.QueryAsync<Student>(query, new { Id = courseId });

            return students.ToList();
        }
    }
}