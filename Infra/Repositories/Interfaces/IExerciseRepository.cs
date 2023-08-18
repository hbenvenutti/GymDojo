using GymAPI.Models;

namespace GymAPI.Infra.Repositories.Interfaces;

public interface IExerciseRepository
{
    ICollection<Exercise> List();
}
