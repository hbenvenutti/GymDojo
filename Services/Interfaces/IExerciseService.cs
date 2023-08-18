using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;

namespace GymAPI.Services.Interfaces;

public interface IExerciseService
{
    ICollection<ReadExerciseDto> ListExercises();
    Task<IReadExerciseDto> GetExerciseAsync(int id);
    Task<IReadExerciseDto> CreateExerciseAsync(CreateExerciseDto createExerciseDto);
    Task<IReadExerciseDto> UpdateExerciseAsync(int id, UpdateExerciseDto updateExerciseDto);
    Task DeleteExerciseAsync(int id);
}
