using GymAPI.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GymAPI.Bootstrap.Database;

public static class DatabaseStarter
{
    public static void Start(
        IServiceCollection services,
        IConfiguration configuration
    ) 
    {
        var connectionString = configuration
            .GetConnectionString("DefaultConnection");

        services.AddDbContext<APIContext>(options => options
            .UseSqlServer(connectionString)
        );
    }
}
