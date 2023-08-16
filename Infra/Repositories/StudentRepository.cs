using GymAPI.Infra.Database;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Models;

namespace GymAPI.Infra.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly APIContext _context;

    // ---------------------------------------------------------------------- //

    public StudentRepository(APIContext context)
    {
        _context = context;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Student> Create(Student student)
    {
        await _context.Students.AddAsync(student);

        await _context.SaveChangesAsync();

        return student;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Student?> FindById(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    // ---------------------------------------------------------------------- //

    public ICollection<Student> List()
    {
        return _context.Students.ToList();
    }

    // ---------------------------------------------------------------------- //

    public async Task<Student> Update(Student student)
    {
        _context.Students.Update(student);

        await _context.SaveChangesAsync();

        return student;
    }

    // ---------------------------------------------------------------------- //

    public bool Exists(int id)
    {
        return _context.Students.Any(student => student.Id == id);
    }
}

