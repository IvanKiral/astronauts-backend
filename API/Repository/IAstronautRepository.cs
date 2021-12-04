using API.DTO;

namespace API.Repository;

public interface IAstronautRepository
{
    public IAsyncEnumerable<Astronaut> GetAllAstronauts();
    public Task<Astronaut> AddAstronaut(Astronaut astronaut);
    public Task<Astronaut> UpdateAstronaut(Astronaut astronaut);
    public Task DeleteAstronaut(Guid id);
}