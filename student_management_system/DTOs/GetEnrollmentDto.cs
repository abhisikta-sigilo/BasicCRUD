namespace StudentManagementSystem.DTOs
{
    public class GetEnrollmentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Percentage { get; set; }
    }
}