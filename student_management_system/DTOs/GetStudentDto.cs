namespace StudentManagementSystem.DTOs
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
    }
}