using AutoMapper;
using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;
using GymAPI.Providers.Mapper.Interfaces;

namespace GymAPI.Providers.Mapper;

public class ExerciseMapper : IExerciseMapper
{
    private readonly IMapper _mapper;

    // ---------------------------------------------------------------------- //

    public ExerciseMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public Exercise ToModel(CreateExerciseDto createExerciseDto) => 
        _mapper.Map<Exercise>(createExerciseDto);

    public Exercise ToModel(UpdateExerciseDto updateExerciseDto) =>
        _mapper.Map<Exercise>(updateExerciseDto);

    public Exercise ToModel(UpdateExerciseDto updateExerciseDto, Exercise exercise) =>
        _mapper.Map(updateExerciseDto, exercise);

    public CreateExerciseDto ToCreateDto(
        UpdateExerciseDto updateExerciseDto
    ) => _mapper.Map<CreateExerciseDto>(updateExerciseDto);

    // ---------------------------------------------------------------------- //

    public IReadExerciseDto ToReadDto(Exercise exercise) => 
        _mapper.Map<ReadExerciseDto>(exercise);

    public ICollection<ReadExerciseDto> ToReadDtoCollection(
        ICollection<Exercise> exercises
    ) => _mapper.Map<ICollection<ReadExerciseDto>>(exercises);
}
