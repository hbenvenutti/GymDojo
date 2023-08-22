using Microsoft.Extensions.DependencyInjection;
using GymDojo.Services.Interfaces;
using GymDojo.Services;

namespace GymDojo.Bootstrap.Services;

public static class ServicesStarter
{
    public static void Start(IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<ITrainingService, TrainingService>();
        services.AddScoped<IStudentService, StudentService>();

        services.AddScoped<IStudentMapper, StudentMapper>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddScoped<ITrainingRepository, TrainingRepository>();

        services.AddScoped<IExerciseMapper, ExerciseMapper>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
    }
}
