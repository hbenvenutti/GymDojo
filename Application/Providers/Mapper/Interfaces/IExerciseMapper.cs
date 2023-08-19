using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface IExerciseMapper : 
    IModelMapper<
        Exercise, 
        CreateExerciseDto, 
        UpdateExerciseDto, 
        IReadExerciseDto, 
        ReadExerciseDto
    >
{}
