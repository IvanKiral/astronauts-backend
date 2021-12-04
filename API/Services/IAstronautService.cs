using API.DTO;

namespace API.Services;

public interface IAstronautService
{
    public IAsyncEnumerable<Astronaut> GetALlAstronauts();

    public Task<Astronaut> AddAstronaut(AddAstronaut astronaut);

    public Task<Astronaut> UpdateAstronaut(Guid id, AddAstronaut astronaut);

    public Task DeleteAstronaut(Guid id);

}