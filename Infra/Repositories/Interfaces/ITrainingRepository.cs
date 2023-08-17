using GymAPI.Models;

namespace GymAPI.Infra.Repositories.Interfaces;

public interface ITrainingRepository
{
    Task<Training> CreateAsync(Training training);
    Task<Training?> FindByIdAsync(int trainingId);
}
