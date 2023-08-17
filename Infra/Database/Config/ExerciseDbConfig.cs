using GymAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymAPI.Infra.Database.Config;

public class ExerciseDbConfig : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder
            .HasKey(exercise => exercise.Id);

        builder
            .Property(exercise => exercise.Name)
            .IsRequired();
        
        builder
            .Property(exercise => exercise.Photo)
            .IsRequired();
        
        builder
            .Property(exercise => exercise.Description)
            .IsRequired(false);
    }
}
