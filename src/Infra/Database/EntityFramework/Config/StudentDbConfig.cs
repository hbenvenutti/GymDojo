using GymDojo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymDojo.Infra.Database.EF.Config;

public class StudentDbConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .HasKey(student => student.Id);

        builder
            .Property(student => student.Name)
            .IsRequired();

        builder
            .Property(student => student.Gender)
            .IsRequired();

        builder
            .Property(student => student.Age)
            .IsRequired();

        builder
            .Property(student => student.Weight)
            .IsRequired();
        
        builder
            .Property(student => student.Height)
            .IsRequired();

        builder
            .Property(student => student.ArmCircumference)
            .IsRequired();

        builder
            .Property(student => student.WaistCircumference)
            .IsRequired();

        builder
            .Property(student => student.AbdomenCircumference)
            .IsRequired();
        
        builder
            .Property(student => student.ChestCircumference)
            .IsRequired();
    }
}
