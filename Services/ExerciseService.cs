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
    private readonly IExerciseMapper _exerciseMapper;

    // ---------------------------------------------------------------------- //

    public ExerciseService(
        IExerciseRepository exerciseRepository, 
        IExerciseMapper exerciseMapper
    )
    {
        _exerciseRepository = exerciseRepository;
        _exerciseMapper = exerciseMapper;
    }

    // ---------------------------------------------------------------------- //

    public ICollection<ReadExerciseDto> ListExercises()
    {
        var exercises = _exerciseRepository.List();
        
        var exercisesDto = _exerciseMapper.ToReadDtoCollection(exercises);

        return exercisesDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadExerciseDto> GetExerciseAsync(int id)
    {
        var exercise = await _exerciseRepository.FindByIdAsync(id) 
            ?? throw new ExerciseNotFoundException();
        
        var exerciseDto = _exerciseMapper.ToReadDto(exercise);

        return exerciseDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadExerciseDto> CreateExerciseAsync(
        CreateExerciseDto createExerciseDto
    )
    {
        var exercise = _exerciseMapper.ToModel(createExerciseDto);
        
        exercise = await _exerciseRepository.CreateAsync(exercise);
        
        var exerciseDto = _exerciseMapper.ToReadDto(exercise);

        return exerciseDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadExerciseDto> UpdateExerciseAsync(
        int id, 
        UpdateExerciseDto updateExerciseDto
    )
    {
        var exercise = await _exerciseRepository.FindByIdAsync(id);

        if (exercise is null) 
            return await CreateExerciseAsync(
                _exerciseMapper.ToCreateDto(updateExerciseDto)
            );
        
        exercise = _exerciseMapper.ToModel(updateExerciseDto, exercise);
        
        exercise = await _exerciseRepository.UpdateAsync(exercise);
        
        var exerciseDto = _exerciseMapper.ToReadDto(exercise);

        return exerciseDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteExerciseAsync(int id)
    {
        var exercise = await _exerciseRepository.FindByIdAsync(id) 
            ?? throw new ExerciseNotFoundException();
        
        await _exerciseRepository.DeleteAsync(exercise);

        return;
    }
}
