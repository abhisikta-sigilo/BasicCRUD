namespace StudentManagementSystem.SqlQueries
{
    public static class StudentSqlQueries
    {
        public const string GetStudents =
            @"SELECT * FROM Students";

        public const string GetStudentById =
            @"SELECT * FROM Students
              WHERE Id = @Id";

        public const string CreateStudent =
            @"INSERT INTO Students (Name, Email)
              VALUES (@Name, @Email);
              SELECT CAST(SCOPE_IDENTITY() as int);";

        public const string UpdateStudent =
            @"UPDATE Students
              SET Name = @Name,
                  Email = @Email
              WHERE Id = @Id";

        public const string DeleteStudent =
            @"DELETE FROM Students
              WHERE Id = @Id";

        public const string GetCoursesByStudentId =
            @"SELECT c.Id, c.CourseName
              FROM Courses c
              INNER JOIN Enrollments e ON c.Id = e.CourseId
              WHERE e.StudentId = @Id";
    }
}