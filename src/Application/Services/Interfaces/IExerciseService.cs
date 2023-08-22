using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;

namespace GymDojo.Services.Interfaces;

public interface IExerciseService : 
    IModelService<
        Exercise, 
        CreateExerciseDto, 
        UpdateExerciseDto, 
        IReadExerciseDto, 
        ReadExerciseDto
    >
{}
