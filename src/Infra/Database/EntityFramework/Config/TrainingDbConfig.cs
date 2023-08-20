using GymDojo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymDojo.Infra.Database.EF.Config;

public class TrainingDbConfig : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder
            .HasKey(training => training.Id);
        
        builder
            .Property(training => training.Name)
            .IsRequired();
        
        builder
            .Property(training => training.StudentId)
            .IsRequired();

        builder
            .HasOne(training => training.Student)
            .WithMany(student => student.Trainings)
            .HasForeignKey(training => training.StudentId);
    }
}
