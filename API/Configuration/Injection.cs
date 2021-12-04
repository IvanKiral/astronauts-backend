using API.DAO;
using API.Repository;
using API.Services;

namespace API.Configuration;

public static class Injection
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddSingleton(DatabaseConnector.GetNotesContainer());
        services.AddSingleton(Mapper.GetMapperInstance());
        services.AddSingleton<ICosmosRepository<Astronaut>, CosmosRepository<Astronaut>>();
        services.AddSingleton<IAstronautRepository, AstronautRepository>();
        services.AddScoped<IAstronautService, AstronautService>();
    }
}