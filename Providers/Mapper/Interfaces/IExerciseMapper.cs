using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface IExerciseMapper
{
    IReadExerciseDto ToReadDto(Exercise exercise);
    ICollection<ReadExerciseDto> ToReadDtoCollection(ICollection<Exercise> exercises);
}
