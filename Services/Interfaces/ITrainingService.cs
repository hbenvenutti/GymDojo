using GymAPI.Dtos.Request;
using GymAPI.Dtos.Response;
using GymAPI.Dtos.Response.interfaces;

namespace GymAPI.Services.Interfaces;

public interface ITrainingService
{
    Task<IReadTrainingDto> CreateTrainingAsync(CreateTrainingDto trainingDto);
    Task<IReadTrainingDto> GetByIdAsync(int trainingId);
    ICollection<ReadTrainingDto> ListByStudent(int studentId);
    Task<IReadTrainingDto> UpdateTrainingAsync(int trainingId, UpdateTrainingDto trainingDto);
    Task DeleteTrainingAsync(int trainingId);
}
