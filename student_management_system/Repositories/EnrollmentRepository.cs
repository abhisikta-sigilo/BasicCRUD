using Dapper;
using Microsoft.Data.SqlClient;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DapperContext _context;

        public EnrollmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            using var connection = _context.CreateConnection();

            var query = "SELECT * FROM Enrollments";

            var enrollments = await connection.QueryAsync<Enrollment>(query);

            return enrollments.ToList();
        }

        public async Task<Enrollment?> GetEnrollmentById(int id)
        {
            using var connection = _context.CreateConnection();

            var query = "SELECT * FROM Enrollments WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Enrollment>(query, new { Id = id });
        }

        public async Task<int> CreateEnrollment(Enrollment enrollment)
        {
            using var connection = _context.CreateConnection();

            var query = @"INSERT INTO Enrollments (StudentId, CourseId, Percentage)
                          VALUES (@StudentId, @CourseId, @Percentage);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

            return await connection.ExecuteScalarAsync<int>(query, enrollment);
        }

        public async Task<int> UpdateEnrollment(Enrollment enrollment)
        {
            using var connection = _context.CreateConnection();

            var query = @"UPDATE Enrollments
                          SET StudentId = @StudentId,
                              CourseId = @CourseId,
                              Percentage = @Percentage
                          WHERE Id = @Id";

            var rowsAffected = await connection.ExecuteAsync(query, enrollment);

            return rowsAffected;
        }

        public async Task<bool> DeleteEnrollment(int id)
        {
            using var connection = _context.CreateConnection();

            var query = "DELETE FROM Enrollments WHERE Id = @Id";

            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

            return rowsAffected > 0;
        }
    }
}