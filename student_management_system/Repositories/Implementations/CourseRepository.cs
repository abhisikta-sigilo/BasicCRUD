using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.SqlQueries;
using System.Data;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class CourseRepository(DapperContext context) : ICourseRepository
    {
        public async Task<IEnumerable<Course>> GetCourses()
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "SELECT * FROM Courses";

            IEnumerable<Course> courses = await connection.QueryAsync<Course>(
                CourseSqlQueries.GetCourses
            );

            return courses.ToList();
        }

        public async Task<Course?> GetCourseById(int courseId)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Course>(
                CourseSqlQueries.GetCourseById, 
                new { Id = courseId }
            );
        }

        public async Task<int> CreateCourse(Course course)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(
                CourseSqlQueries.CreateCourse,
                course
            );
        }

        public async Task<int> UpdateCourse(Course course)
        {
            using IDbConnection connection = context.CreateConnection();

            int rowsAffected = await connection.ExecuteAsync(
                CourseSqlQueries.UpdateCourse,
                course
            );

            return rowsAffected;
        }

        public async Task<bool> DeleteCourse(int courseId)
        {
            using IDbConnection connection = context.CreateConnection();

            int rowsAffected = await connection.ExecuteAsync(
                CourseSqlQueries.DeleteCourse,
                new { Id = courseId }
            );

            return rowsAffected > 0;
        }

        public async Task<IEnumerable<Student>> GetStudentsByCourseId(int courseId)
        {
            using IDbConnection connection = context.CreateConnection();

            IEnumerable<Student> students = await connection.QueryAsync<Student>(
                CourseSqlQueries.GetStudentsByCourseId,
                new { Id = courseId }
            );

            return students.ToList();
        }
    }
}