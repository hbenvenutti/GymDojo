using AutoMapper;
using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Models;

namespace GymDojo.Providers.Mapper.AutoMapper.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();
        CreateMap<UpdateStudentDto, CreateStudentDto>();
        
        CreateMap<Student, ReadStudentDtoWithRelations>()
            .ForMember(
                dest => dest.Trainings, 
                opt => opt.MapFrom(src => src.Trainings));
        
        CreateMap<Student, ReadStudentDto>();
    }
}
