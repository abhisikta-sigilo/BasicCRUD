using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using System.Data;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class EnrollmentRepository(DapperContext context) : IEnrollmentRepository
    {
        public async Task<IEnumerable<Enrollment>> GetAllEnrollments()
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "SELECT * FROM Enrollments";

            IEnumerable<Enrollment> enrollments = await connection.QueryAsync<Enrollment>(query);

            return enrollments.ToList();
        }

        public async Task<Enrollment?> GetEnrollmentById(int id)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "SELECT * FROM Enrollments WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Enrollment>(query, new { Id = id });
        }

        public async Task<int> CreateEnrollment(Enrollment enrollment)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"INSERT INTO Enrollments (StudentId, CourseId, Percentage)
                          VALUES (@StudentId, @CourseId, @Percentage);
                          SELECT CAST(SCOPE_IDENTITY() as int);";

            return await connection.ExecuteScalarAsync<int>(query, enrollment);
        }

        public async Task<int> UpdateEnrollment(Enrollment enrollment)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = @"UPDATE Enrollments
                          SET StudentId = @StudentId,
                              CourseId = @CourseId,
                              Percentage = @Percentage
                          WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(query, enrollment);

            return rowsAffected;
        }

        public async Task<bool> DeleteEnrollment(int id)
        {
            using IDbConnection connection = context.CreateConnection();

            string query = "DELETE FROM Enrollments WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

            return rowsAffected > 0;
        }
    }
}