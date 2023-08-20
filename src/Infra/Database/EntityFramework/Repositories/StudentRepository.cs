using Microsoft.EntityFrameworkCore;
using GymDojo.Domain.Repositories;
using GymDojo.Infra.Database.EF;
using GymDojo.Domain.Entities;

namespace GymDojo.Infra.EF.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly APIContext _context;

    // ---------------------------------------------------------------------- //

    public StudentRepository(APIContext context)
    {
        _context = context;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Student> CreateAsync(Student student)
    {
        await _context.Students.AddAsync(student);

        await _context.SaveChangesAsync();

        return student;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Student?> FindByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    // ---------------------------------------------------------------------- //

    public ICollection<Student> List()
    {
        return _context
            .Students
            .Include(student => student.Trainings)
            .ToList();
    }

    // ---------------------------------------------------------------------- //

    public async Task<Student> UpdateAsync(Student student)
    {
        _context.Students.Update(student);

        await _context.SaveChangesAsync();

        return student;
    }

    // ---------------------------------------------------------------------- //

    public async Task<bool> Exists(int id)
    {
        return await _context.Students.AnyAsync(student => student.Id == id);
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteAsync(Student student)
    {
        _context.Students.Remove(student);

        await _context.SaveChangesAsync();

        return;
    }
}

