using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    public class EnrollmentService(IEnrollmentRepository enrollmentRepository) : IEnrollmentService
    {
        public async Task<IEnumerable<EnrollmentResponseDto>> GetEnrollments()
        {
            // get entities from database
            IEnumerable<Enrollment> enrollments = await enrollmentRepository.GetEnrollments();


            // get entities from database
            IEnumerable<EnrollmentResponseDto> enrollmentDtos = enrollments.Select(e => new EnrollmentResponseDto
            {
                Id = e.Id,
                StudentId = e.StudentId,
                CourseId = e.CourseId,
                Percentage = e.Percentage
            });

            return enrollmentDtos;
        }


        public async Task<EnrollmentResponseDto?> GetEnrollmentById(int id)
        {
            Enrollment? enrollment = await enrollmentRepository.GetEnrollmentById(id);

            if (enrollment == null)
                return null;

            EnrollmentResponseDto enrollmentDto = new EnrollmentResponseDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                Percentage = enrollment.Percentage
            };

            return enrollmentDto;
        }


        public async Task<EnrollmentResponseDto> CreateEnrollment(CreateEnrollmentDto createDto)
        {
            // convert CreateEnrollmentDto to Enrollment Entity
            Enrollment enrollment = new Enrollment
            {
                StudentId = createDto.StudentId,
                CourseId = createDto.CourseId,
                Percentage = createDto.Percentage
            };

            // save course to database
            int id = await enrollmentRepository.CreateEnrollment(enrollment);


            // convert entity to EnrollmentResponseDto
            EnrollmentResponseDto enrollmentDto = new EnrollmentResponseDto
            {
                Id = id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                Percentage = enrollment.Percentage
            };

            return enrollmentDto;
        }


        public async Task<bool> UpdateEnrollment(int id, UpdateEnrollmentDto updateDto)
        {
            Enrollment enrollment = new Enrollment
            {
                Id = id,
                StudentId = updateDto.StudentId,
                CourseId = updateDto.CourseId,
                Percentage = updateDto.Percentage
            };

            int rows = await enrollmentRepository.UpdateEnrollment(enrollment);

            return rows > 0;
        }


        public async Task<bool> DeleteEnrollment(int id)
        {
            bool deleted = await enrollmentRepository.DeleteEnrollment(id);

            return deleted;
        }
    }
}
