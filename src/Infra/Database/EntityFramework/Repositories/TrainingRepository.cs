using GymDojo.Domain.Entities;
using GymDojo.Domain.Repositories;
using GymDojo.Infra.Database.EF;
using GymDojo.Infra.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GymDojo.Infra.EF.Repositories;

public class TrainingRepository : ITrainingRepository
{
    private readonly APIContext _context;

    // ---------------------------------------------------------------------- //

    public TrainingRepository(APIContext context)
    {
        _context = context;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Training> CreateAsync(Training training)
    {
        var student = await _context
            .Students
            .FindAsync(training.StudentId)
            ?? throw new InvalidForeignKeyException();
        
        await _context
            .Trainings
            .AddAsync(training);

        training.Student = student;

        await _context
            .SaveChangesAsync();

        return training;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Training?> FindByIdAsync(int trainingId)
    {
        return await _context
            .Trainings
            .Include(training => training.Student)
            .FirstOrDefaultAsync(training => training.Id == trainingId);
    }

    // ---------------------------------------------------------------------- //

    public ICollection<Training> FindByStudent(int studentId)
    {
        return _context
            .Trainings
            .Where(training => training.StudentId == studentId)
            .ToList();
    }

    // ---------------------------------------------------------------------- //

    public async Task<Training> UpdateAsync(Training training)
    {
        var studentExists = await _context
            .Students
            .AnyAsync(student => student.Id == training.StudentId);
        
        if (!studentExists) throw new InvalidForeignKeyException();

        _context
            .Trainings
            .Update(training);

        await _context
            .SaveChangesAsync();

        return training;
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteAsync(Training training)
    {
        _context
            .Trainings
            .Remove(training);

        await _context
            .SaveChangesAsync();
    }

    // ---------------------------------------------------------------------- //

    public async Task<bool> Exists(int id)
    {
        return await _context
            .Trainings
            .AnyAsync(training => training.Id == id);
    }

    // ---------------------------------------------------------------------- //

    public ICollection<Training> List()
    {
        throw new NotImplementedException();
    }
}
