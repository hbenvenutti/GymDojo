using AutoMapper;
using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();
        CreateMap<UpdateStudentDto, CreateStudentDto>();
        CreateMap<Student, ReadStudentDto>();
    }
}
