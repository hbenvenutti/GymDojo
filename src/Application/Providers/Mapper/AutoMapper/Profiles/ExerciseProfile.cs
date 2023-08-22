using AutoMapper;
using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Models;

namespace GymDojo.Providers.Mapper.AutoMapper.Profiles;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<CreateExerciseDto, Exercise>();
        CreateMap<UpdateExerciseDto, Exercise>();
        CreateMap<UpdateExerciseDto, CreateExerciseDto>();
        CreateMap<Exercise, ReadExerciseDto>();
    }
}
