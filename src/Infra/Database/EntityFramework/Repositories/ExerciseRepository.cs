using Microsoft.EntityFrameworkCore;
using GymDojo.Domain.Repositories;
using GymDojo.Infra.Database.EF;
using GymDojo.Domain.Entities;

namespace GymDojo.Infra.EF.Repositories;

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

    public async Task<Exercise?> FindByIdAsync(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);

        return exercise;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Exercise> CreateAsync(Exercise exercise)
    {
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();

        return exercise;
    }

    // ---------------------------------------------------------------------- //

    public async Task<Exercise> UpdateAsync(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();

        return exercise;
    }

    // ---------------------------------------------------------------------- //

    public async Task DeleteAsync(Exercise exercise)
    {
        _context.Exercises.Remove(exercise);

        await _context.SaveChangesAsync();

        return;
    }

    // ---------------------------------------------------------------------- //

    public async Task<bool> Exists(int id)
    {
        return await _context.Exercises.AnyAsync(exercise => exercise.Id == id);
    }
}
