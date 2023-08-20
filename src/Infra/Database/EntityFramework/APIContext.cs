using Microsoft.EntityFrameworkCore;

using GymDojo.Infra.Database.Config;
using GymDojo.Domain.Entities;

namespace GymDojo.Infra.Database.EF;

public class APIContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Exercise> Exercises { get; set; }

    // ---------------------------------------------------------------------- //

    public APIContext(DbContextOptions<APIContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentDbConfig());
        modelBuilder.ApplyConfiguration(new TrainingDbConfig());
        modelBuilder.ApplyConfiguration(new ExerciseDbConfig());
    }
}
