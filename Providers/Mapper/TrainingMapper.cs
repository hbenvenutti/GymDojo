using AutoMapper;
using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;
using GymAPI.Providers.Mapper.Interfaces;

namespace GymAPI.Providers.Mapper;

public class TrainingMapper : ITrainingMapper
{
    private readonly IMapper _mapper;

    // ---------------------------------------------------------------------- //

    public TrainingMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public Training ToTraining(CreateTrainingDto dto) =>
        _mapper.Map<Training>(dto);

    public Training ToTraining(UpdateTrainingDto dto) => 
        _mapper.Map<Training>(dto);
    
    public Training ToTraining(UpdateTrainingDto dto, Training training) =>
        _mapper.Map(dto, training);

    // ---------------------------------------------------------------------- //

    public CreateTrainingDto ToCreateDto(UpdateTrainingDto dto) =>
        _mapper.Map<CreateTrainingDto>(dto);

    // ---------------------------------------------------------------------- //

    public IReadTrainingDto ToReadDto(Training training) => 
        _mapper.Map<ReadTrainingDto>(training);

    public ICollection<ReadTrainingDto> ToReadDtoCollection(ICollection<Training> trainings) => 
        _mapper.Map<ICollection<ReadTrainingDto>>(trainings);

    // ---------------------------------------------------------------------- //

    public IReadTrainingDto ToReadDtoWithRelations(Training training) =>
        _mapper.Map<ReadTrainingDtoWithRelations>(training);

    public ICollection<ReadTrainingDtoWithRelations> ToReadDtoWithRelationsCollection(
        ICollection<Training> trainings
    ) => _mapper.Map<ICollection<ReadTrainingDtoWithRelations>>(trainings);
}
