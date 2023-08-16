using GymAPI.Models;

namespace GymAPI.Infra.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<Student> Create(Student student);
    Task<Student?> FindById(int id);
}
