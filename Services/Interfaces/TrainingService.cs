
using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Providers.Mapper.Interfaces;

namespace GymAPI.Services.Interfaces;

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

    public async Task<ReadTrainingDto> CreateTrainingAsync(CreateTrainingDto trainingDto)
    {
        var training = _trainingMapper.ToTraining(trainingDto);

        training = await _trainingRepository.Create(training);

        return _trainingMapper.ToReadDto(training);
    }
}
