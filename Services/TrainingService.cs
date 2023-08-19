using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Exceptions;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Providers.Mapper.Interfaces;
using GymAPI.Services.Interfaces;

namespace GymAPI.Services;

public class TrainingService : ITrainingService
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IMapperProvider _mapper;

    // ---------------------------------------------------------------------- //

    public TrainingService(
        ITrainingRepository trainingRepository,
        IMapperProvider mapper 
    )
    {
        _trainingRepository = trainingRepository;
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadTrainingDto> CreateAsync(
        CreateTrainingDto createDto
    )
    {
        var training = _mapper
            .TrainingMapper
            .ToModel(createDto);
    
        training = await _trainingRepository
            .CreateAsync(training);

        var trainingDto =_mapper
            .TrainingMapper
            .ToReadDtoWithRelations(training);

        return trainingDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadTrainingDto> GetByIdAsync(int trainingId)
    {
        var training = await _trainingRepository
            .FindByIdAsync(trainingId)
            ?? throw new TrainingNotFoundException();

        var trainingDto =_mapper
            .TrainingMapper
            .ToReadDtoWithRelations(training);

        return trainingDto;
    }

    // ---------------------------------------------------------------------- //

    public ICollection<ReadTrainingDto> ListByStudent(int studentId)
    {
        var trainings = _trainingRepository
            .FindByStudent(studentId);

        var trainingsDto =_mapper
            .TrainingMapper
            .ToReadDtoCollection(trainings);

        return trainingsDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task<IReadTrainingDto> UpdateAsync(
        int trainingId, 
        UpdateTrainingDto updateDto
    )
    {
        var training = await _trainingRepository
            .FindByIdAsync(trainingId);

        if (training is null)
            return await CreateAsync(
                _mapper
                    .TrainingMapper
                    .ToCreateDto(updateDto)
            );
            
        training = _mapper
            .TrainingMapper
            .ToExistentModel(updateDto, training);

        training = await _trainingRepository
            .UpdateAsync(training);

        var trainingDto =_mapper
            .TrainingMapper
            .ToReadDtoWithRelations(training);

        return trainingDto;
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteByIdAsync(int trainingId)
    {
        var training = await _trainingRepository
            .FindByIdAsync(trainingId)
            ?? throw new TrainingNotFoundException();

        await _trainingRepository
            .DeleteAsync(training);
    }

    // ---------------------------------------------------------------------- //

    public ICollection<ReadTrainingDtoWithRelations> List()
    {
        var trainings = _trainingRepository
            .List();

        var trainingsDto =_mapper
            .TrainingMapper
            .ToReadDtoWithRelationsCollection(trainings);

        return trainingsDto;
    }
}
