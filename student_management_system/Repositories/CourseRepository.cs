using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DapperContext _context;

        public CourseRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            using var connection = _context.CreateConnection();

            var query = "SELECT * FROM Courses";

            var courses = await connection.QueryAsync<Course>(query);

            return courses.ToList();
        }

        public async Task<Course?> GetCourseById(int id)
        {
            using var connection = _context.CreateConnection();

            var query = "SELECT * FROM Courses WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Course>(query, new { Id = id });
        }

        public async Task<int> CreateCourse(Course course)
        {
            using var connection = _context.CreateConnection();

            var query = @"INSERT INTO Courses (CourseName)
                          VALUES (@CourseName);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

            return await connection.ExecuteScalarAsync<int>(query, course);
        }

        public async Task<int> UpdateCourse(Course course)
        {
            using var connection = _context.CreateConnection();

            var query = @"UPDATE Courses
                          SET CourseName = @CourseName
                          WHERE Id = @Id";

            var rowsAffected = await connection.ExecuteAsync(query, course);

            return rowsAffected;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            using var connection = _context.CreateConnection();

            var query = "DELETE FROM Courses WHERE Id = @Id";

            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

            return rowsAffected > 0;
        }
    }
}