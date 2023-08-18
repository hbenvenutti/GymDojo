using GymAPI.Infra.Database;
using GymAPI.Infra.Repositories.Interfaces;
using GymAPI.Models;

namespace GymAPI.Infra.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly APIContext _context;

    // ---------------------------------------------------------------------- //

    public ExerciseRepository(APIContext context)
    {
        _context = context;
    }

    // ---------------------------------------------------------------------- //

    public ICollection<Exercise> List()
    {
        var exercises = _context.Exercises.ToList();

        return exercises;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Exercise?> FindById(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);

        return exercise;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Exercise> Create(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();

        return exercise;
    }
}
