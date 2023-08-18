using GymAPI.Models;

namespace GymAPI.Infra.Repositories.Interfaces;

public interface IExerciseRepository
{
    ICollection<Exercise> List();
    Task<Exercise?> FindById(int id);
    Task<Exercise> Create(Exercise exercise);
    Task<Exercise> Update(Exercise exercise);
}
