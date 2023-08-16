using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;

namespace GymAPI.Services.Interfaces;

public interface ITrainingService
{
    Task<ReadTrainingDto> CreateTrainingAsync(CreateTrainingDto trainingDto);
}
