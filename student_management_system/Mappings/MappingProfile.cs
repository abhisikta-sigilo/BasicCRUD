using AutoMapper;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Course mappings
            CreateMap<Course, CourseResponseDto>();
            CreateMap<CreateCourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();

            // Student mappings
            CreateMap<Student, StudentResponseDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();

            // Enrollment mappings
            CreateMap<Enrollment, EnrollmentResponseDto>();
            CreateMap<CreateEnrollmentDto, Enrollment>();
            CreateMap<UpdateEnrollmentDto, Enrollment>();
        }
    }
}