using AutoMapper;
using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Profiles;

public class TrainingProfile : Profile
{
    public TrainingProfile()
    {
        CreateMap<CreateTrainingDto, Training>();

        CreateMap<UpdateTrainingDto, Training>();

        CreateMap<UpdateTrainingDto, CreateTrainingDto>();

        CreateMap<Training, ReadTrainingDto>()
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student));
    }
}
