using GymAPI.Dtos.Response;

namespace GymAPI.Services.Interfaces;

public interface IExerciseService
{
    ICollection<ReadExerciseDto> ListExercises();
}
