namespace GymAPI.Infra.Repositories.Interfaces;

public interface IRepository<Type>
{
    Task<Type> CreateAsync(Type data);
    Task<Type?> FindByIdAsync(int id);
    ICollection<Type> List();
    Task<Type> UpdateAsync(Type data);
    Task DeleteAsync(Type data);
    Task<bool> Exists(int id);
}
