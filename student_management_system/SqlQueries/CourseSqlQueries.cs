namespace StudentManagementSystem.SqlQueries
{
    public static class CourseSqlQueries
    {
        public const string GetCourses =
            @"SELECT * FROM Courses";

        public const string GetCourseById =
            @"SELECT * FROM Courses
              WHERE Id = @Id";

        public const string CreateCourse =
            @"INSERT INTO Courses (CourseName)
              VALUES (@CourseName);
              SELECT CAST(SCOPE_IDENTITY() as int);";

        public const string UpdateCourse =
            @"UPDATE Courses
              SET CourseName = @CourseName
              WHERE Id = @Id";

        public const string DeleteCourse =
            @"DELETE FROM Courses
              WHERE Id = @Id";

        public const string GetStudentsByCourseId =
            @"SELECT s.Id, s.Name, s.Email
              FROM Students s
              INNER JOIN Enrollments e ON s.Id = e.StudentId
              WHERE e.CourseId = @Id";
    }
}