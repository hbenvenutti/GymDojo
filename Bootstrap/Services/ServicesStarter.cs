using Microsoft.Extensions.DependencyInjection;
using GymAPI.

namespace GymAPI.Bootstrap.Services;

public class ServicesStarter
{
    public void Start(IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
    }
}
