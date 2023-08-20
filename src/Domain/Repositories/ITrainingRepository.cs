using GymDojo.Domain.Entities;

namespace GymDojo.Domain.Repositories;

public interface ITrainingRepository : IRepository<Training>
{
    ICollection<Training> FindByStudent(int studentId);
}
