using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response.interfaces;

namespace GymAPI.Services.Interfaces;

public interface ITrainingService
{
    Task<IReadTrainingDto> CreateTrainingAsync(CreateTrainingDto trainingDto);
    Task<IReadTrainingDto> GetByIdAsync(int trainingId);
}
