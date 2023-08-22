namespace Bootstrap.Providers;

public static class ProvidersStarter
{
    public static void Start(IServiceCollection services)
    {
        services.AddScoped<ITrainingMapper, TrainingMapper>();
    }    
}
