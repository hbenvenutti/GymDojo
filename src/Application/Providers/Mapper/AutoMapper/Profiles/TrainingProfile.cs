using AutoMapper;
using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Models;

namespace GymDojo.Providers.Mapper.AutoMapper.Profiles;

public class TrainingProfile : Profile
{
    public TrainingProfile()
    {
        CreateMap<CreateTrainingDto, Training>();

        CreateMap<UpdateTrainingDto, Training>();

        CreateMap<UpdateTrainingDto, CreateTrainingDto>();

        CreateMap<Training, ReadTrainingDtoWithRelations>()
            .ForMember(
                dest => dest.Student, 
                opt => opt.MapFrom(src => src.Student)
            );

        CreateMap<Training, ReadTrainingDto>();
        
    }
}
