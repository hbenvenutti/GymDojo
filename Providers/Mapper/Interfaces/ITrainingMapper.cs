using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Models;

namespace GymAPI.Providers.Mapper.Interfaces;

public interface ITrainingMapper
{
    Training ToTraining(CreateTrainingDto dto);
    Training ToTraining(UpdateTrainingDto dto);
    Training ToTraining(UpdateTrainingDto dto, Training training);

    ReadTrainingDto ToReadDto(Training training);
    ICollection<ReadTrainingDto> ToReadDto(ICollection<Training> trainings);
}
