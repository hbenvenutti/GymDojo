using GymAPI.Models;

namespace GymAPI.Infra.Repositories.Interfaces;

public interface ITrainingRepository
{
    Task<Training> Create(Training training);
}
