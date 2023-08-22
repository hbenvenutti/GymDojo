using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;

namespace GymDojo.Providers.Mapper.Interfaces;

public interface IExerciseMapper : 
    IModelMapper<
        Exercise, 
        CreateExerciseDto, 
        UpdateExerciseDto, 
        IReadExerciseDto, 
        ReadExerciseDto
    >
{}
