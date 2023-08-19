using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Exceptions;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Providers.Mapper.Interfaces;
using GymAPI.Services.Interfaces;

namespace GymAPI.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapperProvider _mapper;

    // ---------------------------------------------------------------------- //

    public ExerciseService(
        IExerciseRepository exerciseRepository, 
        IMapperProvider mapper
    )
    {
        _exerciseRepository = exerciseRepository;
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public ICollection<ReadExerciseDto> List()
    {
        var exercises = _exerciseRepository
            .List();
        
        var exercisesDto = _mapper
            .ExerciseMapper
            .ToReadDtoCollection(exercises);

        return exercisesDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadExerciseDto> GetByIdAsync(int exerciseId)
    {
        var exercise = await _exerciseRepository
            .FindByIdAsync(exerciseId) 
            ?? throw new ExerciseNotFoundException();
        
        var exerciseDto = _mapper
            .ExerciseMapper
            .ToReadDto(exercise);

        return exerciseDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadExerciseDto> CreateAsync(
        CreateExerciseDto createDto
    )
    {
        var exercise = _mapper
            .ExerciseMapper
            .ToModel(createDto);
        
        exercise = await _exerciseRepository
            .CreateAsync(exercise);
        
        var exerciseDto = _mapper
            .ExerciseMapper
            .ToReadDto(exercise);

        return exerciseDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadExerciseDto> UpdateAsync(
        int exerciseId, 
        UpdateExerciseDto updateDto
    )
    {
        var exercise = await _exerciseRepository
            .FindByIdAsync(exerciseId);

        if (exercise is null) 
            return await CreateAsync(
                _mapper
                .ExerciseMapper
                .ToCreateDto(updateDto)
            );
        
        exercise = _mapper
            .ExerciseMapper
            .ToExistentModel(updateDto, exercise);
        
        exercise = await _exerciseRepository
            .UpdateAsync(exercise);
        
        var exerciseDto = _mapper
            .ExerciseMapper
            .ToReadDto(exercise);

        return exerciseDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteByIdAsync(int exerciseId)
    {
        var exercise = await _exerciseRepository
            .FindByIdAsync(exerciseId) 
            ?? throw new ExerciseNotFoundException();
        
        await _exerciseRepository
            .DeleteAsync(exercise);

        return;
    }
}
