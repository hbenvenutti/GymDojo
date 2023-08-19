using GymAPI.Models;

namespace GymAPI.Infra.Repositories.Interfaces;

public interface ITrainingRepository : IRepository<Training>
{
    ICollection<Training> FindByStudent(int studentId);
}
