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
}
