using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services
{
    public class EnrollmentService(IEnrollmentRepository enrollmentRepository) : IEnrollmentService
    {
        public async Task<IEnumerable<GetEnrollmentDto>> GetAllEnrollments()
        {
            // get entities from database
            var enrollments = await enrollmentRepository.GetAllEnrollments();


            // get entities from database
            var enrollmentDtos = enrollments.Select(e => new GetEnrollmentDto
            {
                Id = e.Id,
                StudentId = e.StudentId,
                CourseId = e.CourseId,
                Percentage = e.Percentage
            });

            return enrollmentDtos;
        }


        public async Task<GetEnrollmentDto?> GetEnrollmentById(int id)
        {

            var enrollment = await enrollmentRepository.GetEnrollmentById(id);

            if (enrollment == null)
                return null;

            var enrollmentDto = new GetEnrollmentDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                Percentage = enrollment.Percentage
            };

            return enrollmentDto;
        }


        public async Task<GetEnrollmentDto> CreateEnrollment(CreateEnrollmentDto createDto)
        {
            // convert CreateEnrollmentDto to Enrollment Entity
            var enrollment = new Enrollment
            {
                StudentId = createDto.StudentId,
                CourseId = createDto.CourseId,
                Percentage = createDto.Percentage
            };

            // save course to database
            var id = await enrollmentRepository.CreateEnrollment(enrollment);


            // convert entity to GetEnrollmentDto
            var enrollmentDto = new GetEnrollmentDto
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
            var enrollment = new Enrollment
            {
                Id = id,
                StudentId = updateDto.StudentId,
                CourseId = updateDto.CourseId,
                Percentage = updateDto.Percentage
            };

            var rows = await enrollmentRepository.UpdateEnrollment(enrollment);

            return rows > 0;
        }


        public async Task<bool> DeleteEnrollment(int id)
        {
            bool deleted = await enrollmentRepository.DeleteEnrollment(id);

            return deleted;
        }
    }
}
