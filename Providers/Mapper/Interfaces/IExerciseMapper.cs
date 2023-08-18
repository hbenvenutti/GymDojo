using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface IExerciseMapper
{
    Exercise ToModel(CreateExerciseDto createExerciseDto);
    Exercise ToModel(UpdateExerciseDto updateExerciseDto);
    Exercise ToModel(UpdateExerciseDto updateExerciseDto, Exercise exercise);
    CreateExerciseDto ToCreateDto(UpdateExerciseDto updateExerciseDto);

    IReadExerciseDto ToReadDto(Exercise exercise);
    ICollection<ReadExerciseDto> ToReadDtoCollection(ICollection<Exercise> exercises);
}
