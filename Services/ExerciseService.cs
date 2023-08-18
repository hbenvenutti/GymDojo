using GymAPI.Dtos.Response;
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
}
