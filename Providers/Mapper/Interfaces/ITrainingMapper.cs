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

    IReadTrainingDto ToReadDto(Training training);
    ICollection<ReadTrainingDto> ToReadDto(ICollection<Training> trainings);

    IReadTrainingDto ToReadDtoWithRelations(Training training);
    ICollection<ReadTrainingDtoWithRelations> ToReadDtoWithRelations(ICollection<Training> trainings);
}
