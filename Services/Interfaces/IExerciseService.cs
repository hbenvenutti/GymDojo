using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Services.Interfaces;

public interface IExerciseService : 
    IModelService<
        Exercise, 
        CreateExerciseDto, 
        UpdateExerciseDto, 
        IReadExerciseDto, 
        ReadExerciseDto
    >
{}
