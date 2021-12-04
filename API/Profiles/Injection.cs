using API.Repository;
using API.Services;

namespace API.Profiles;

public static class Injection
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAstronautService, AstronautService>();
        services.AddSingleton<IAstronautRepository, InMemoryAstronautRepository>();
    }
}