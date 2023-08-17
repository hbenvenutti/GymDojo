using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Exceptions;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Providers.Mapper.Interfaces;
using GymAPI.Services.Interfaces;

namespace GymAPI.Services;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly ITrainingMapper _trainingMapper;

    // ---------------------------------------------------------------------- //

    public TrainingService(
        ITrainingMapper trainingMapper, 
        ITrainingRepository trainingRepository
    )
    {
        _trainingMapper = trainingMapper;
        _trainingRepository = trainingRepository;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadTrainingDto> CreateTrainingAsync(
        CreateTrainingDto createDto
    )
    {
        var training = _trainingMapper.
            ToTraining(createDto);
    

        training = await _trainingRepository.CreateAsync(training);

        var trainingDto =_trainingMapper.ToReadDtoWithRelations(training);

        return trainingDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadTrainingDto> GetByIdAsync(int trainingId)
    {
        var training = await _trainingRepository.FindByIdAsync(trainingId)
            ?? throw new TrainingNotFoundException();

        var trainingDto =_trainingMapper.ToReadDtoWithRelations(training);

        return trainingDto;
    }
}
