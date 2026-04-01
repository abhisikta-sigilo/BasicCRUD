namespace StudentManagementSystem.SqlQueries
{
    public static class EnrollmentSqlQueries
    {
        public const string GetEnrollments =
            @"SELECT * FROM Enrollments";

        public const string GetEnrollmentById =
            @"SELECT * FROM Enrollments
              WHERE Id = @Id";

        public const string CreateEnrollment =
            @"INSERT INTO Enrollments (StudentId, CourseId, Percentage)
              VALUES (@StudentId, @CourseId, @Percentage);
              SELECT CAST(SCOPE_IDENTITY() as int);";

        public const string UpdateEnrollment =
            @"UPDATE Enrollments
              SET StudentId = @StudentId,
                  CourseId = @CourseId,
                  Percentage = @Percentage
              WHERE Id = @Id";

        public const string DeleteEnrollment =
            @"DELETE FROM Enrollments
              WHERE Id = @Id";
    }
}