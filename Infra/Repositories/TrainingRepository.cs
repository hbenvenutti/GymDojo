using GymAPI.Exceptions;
using GymAPI.Infra.Database;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAPI.Infra.Repositories;

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
            ?? throw new InexistentStudentException();
        
        await _context
            .Trainings
            .AddAsync(training);

        training.Student = student;

        await _context.SaveChangesAsync();

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
            // .Include(training => training.Student)
            .Where(training => training.StudentId == studentId)
            .ToList();
    }

    // ---------------------------------------------------------------------- //

    public async Task<Training> UpdateAsync(Training training)
    {
        var studentExists = await _context
            .Students
            .AnyAsync(student => student.Id == training.StudentId);
        
        if (!studentExists) throw new InexistentStudentException();

        _context
            .Trainings
            .Update(training);

        await _context.SaveChangesAsync();

        return training;
    }
}
