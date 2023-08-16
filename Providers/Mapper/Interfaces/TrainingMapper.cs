using AutoMapper;
using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public class TrainingMapper : ITrainingMapper
{
    private readonly IMapper _mapper;

    // ---------------------------------------------------------------------- //

    public TrainingMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    // ---------------------------------------------------------------------- //

    public ReadTrainingDto ToReadDto(Training training) => 
        _mapper.Map<ReadTrainingDto>(training);

    public ICollection<ReadTrainingDto> ToReadDto(ICollection<Training> trainings) => 
        _mapper.Map<ICollection<ReadTrainingDto>>(trainings);

    public Training ToTraining(CreateTrainingDto dto) =>
        _mapper.Map<Training>(dto);

    public Training ToTraining(UpdateTrainingDto dto) => 
        _mapper.Map<Training>(dto);
    
    public Training ToTraining(UpdateTrainingDto dto, Training training) =>
        _mapper.Map(dto, training);
}
