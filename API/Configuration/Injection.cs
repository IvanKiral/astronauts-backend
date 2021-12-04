using API.Repository;
using API.Services;

namespace API.Configuration;

public static class Injection
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddScoped<IAstronautService, AstronautService>();
        services.AddSingleton<IAstronautRepository, InMemoryAstronautRepository>();
        services.AddSingleton(Mapper.GetMapperInstance());
    }
}