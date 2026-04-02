using AutoMapper;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Services.Abstractions;

namespace StudentManagementSystem.Services.Implementations
{
    public class EnrollmentService(
        IEnrollmentRepository enrollmentRepository,
        IMapper mapper
    ) : IEnrollmentService
    {
        public async Task<IEnumerable<EnrollmentResponseDto>> GetEnrollments()
        {
            // get entities from database
            IEnumerable<Enrollment> enrollments = await enrollmentRepository.GetEnrollments();

            return mapper.Map<IEnumerable<EnrollmentResponseDto>>(enrollments);
        }


        public async Task<EnrollmentResponseDto?> GetEnrollmentById(int enrollmentId)
        {
            Enrollment? enrollment = await enrollmentRepository.GetEnrollmentById(enrollmentId);

            if (enrollment == null)
                return null;

            return mapper.Map<EnrollmentResponseDto>(enrollment);
        }


        public async Task<EnrollmentResponseDto> CreateEnrollment(CreateEnrollmentDto createDto)
        {
            // convert CreateEnrollmentDto to Enrollment Entity
            Enrollment enrollment = mapper.Map<Enrollment>(createDto);

            // save course to database
            int id = await enrollmentRepository.CreateEnrollment(enrollment);

            // map back to response
            EnrollmentResponseDto enrollmentDto =
                mapper.Map<EnrollmentResponseDto>(enrollment);

            enrollmentDto.Id = id;

            return enrollmentDto;
        }


        public async Task<bool> UpdateEnrollment(int enrollmentId, UpdateEnrollmentDto updateDto)
        {
            Enrollment enrollment = mapper.Map<Enrollment>(updateDto);
            enrollment.Id = enrollmentId;

            int rows = await enrollmentRepository.UpdateEnrollment(enrollment);

            return rows > 0;
        }


        public async Task<bool> DeleteEnrollment(int enrollmentId)
        {
            return await enrollmentRepository.DeleteEnrollment(enrollmentId);
        }
    }
}
