using API.DTO;

namespace API.Services;

public interface IAstronautService
{
    public IAsyncEnumerable<Astronaut> GetALlAstronauts();

    public Task<Astronaut> AddAstronaut(AddAstronaut astronaut);

    public Task<Astronaut> UpdateAstronaut(Astronaut astronaut);

    public Task DeleteAstronaut(Guid id);

}