namespace StudentManagementSystem.DTOs
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
    }
}