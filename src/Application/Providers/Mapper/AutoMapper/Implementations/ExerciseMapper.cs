using AutoMapper;
using GymDojo.Dtos.Request;
using GymDojo.Dtos.Response;
using GymDojo.Dtos.Response.interfaces;
using GymDojo.Models;
using GymDojo.Providers.Mapper.Interfaces;

namespace GymDojo.Providers.Mapper.AutoMapper.Implementations;

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

    // ---------------------------------------------------------------------- //

    public Exercise ToExistentModel(
        UpdateExerciseDto updateExerciseDto, 
        Exercise exercise
    ) => _mapper.Map(updateExerciseDto, exercise);

    // ---------------------------------------------------------------------- //

    public CreateExerciseDto ToCreateDto(
        UpdateExerciseDto updateExerciseDto
    ) => _mapper.Map<CreateExerciseDto>(updateExerciseDto);

    // ---------------------------------------------------------------------- //

    public IReadExerciseDto ToReadDto(Exercise exercise) => 
        _mapper.Map<ReadExerciseDto>(exercise);

    // ---------------------------------------------------------------------- //
    
    public ICollection<ReadExerciseDto> ToReadDtoCollection(
        ICollection<Exercise> exercises
    ) => _mapper.Map<ICollection<ReadExerciseDto>>(exercises);
}
