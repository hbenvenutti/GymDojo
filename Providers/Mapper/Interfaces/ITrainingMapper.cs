using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface ITrainingMapper
{
    Training ToTraining(CreateTrainingDto dto);
    Training ToTraining(UpdateTrainingDto dto);
    Training ToTraining(UpdateTrainingDto dto, Training training);

    CreateTrainingDto ToCreateDto(UpdateTrainingDto dto);

    IReadTrainingDto ToReadDto(Training training);
    ICollection<ReadTrainingDto> ToReadDtoCollection(ICollection<Training> trainings);

    IReadTrainingDto ToReadDtoWithRelations(Training training);
    ICollection<ReadTrainingDtoWithRelations> ToReadDtoWithRelationsCollection(ICollection<Training> trainings);
}
