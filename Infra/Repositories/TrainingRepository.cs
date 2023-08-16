using GymAPI.Infra.Database;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Models;

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

    public async Task<Training> Create(Training training)
    {
        await _context.Trainings.AddAsync(training);

        await _context.SaveChangesAsync();

        return training;
    }
}
