using Dapper;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.SqlQueries;
using System.Data;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class EnrollmentRepository(DapperContext context) : IEnrollmentRepository
    {
        public async Task<IEnumerable<Enrollment>> GetEnrollments()
        {
            using IDbConnection connection = context.CreateConnection();

            IEnumerable<Enrollment> enrollments = await connection.QueryAsync<Enrollment>(
                EnrollmentSqlQueries.GetEnrollments
            );

            return enrollments.ToList();
        }

        public async Task<Enrollment?> GetEnrollmentById(int enrollmentId)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Enrollment>(
                EnrollmentSqlQueries.GetEnrollmentById,
                new { Id = enrollmentId }
            );
        }

        public async Task<int> CreateEnrollment(Enrollment enrollment)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.ExecuteScalarAsync<int>(
                EnrollmentSqlQueries.CreateEnrollment,
                enrollment
            );
        }

        public async Task<int> UpdateEnrollment(Enrollment enrollment)
        {
            using IDbConnection connection = context.CreateConnection();

            int rowsAffected = await connection.ExecuteAsync(
                EnrollmentSqlQueries.UpdateEnrollment,
                enrollment
            );

            return rowsAffected;
        }

        public async Task<bool> DeleteEnrollment(int enrollmentId)
        {
            using IDbConnection connection = context.CreateConnection();
            
            int rowsAffected = await connection.ExecuteAsync(
                EnrollmentSqlQueries.DeleteEnrollment, 
                new { Id = enrollmentId }
            );

            return rowsAffected > 0;
        }
    }
}