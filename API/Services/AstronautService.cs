using API.DTO;
using API.Repository;

namespace API.Services;

public class AstronautService: IAstronautService
{
    public IAsyncEnumerable<Astronaut> GetALlAstronauts()
    {
        throw new NotImplementedException();
    }

    public Task<Astronaut> AddAstronaut(AddAstronaut astronaut)
    {
        throw new NotImplementedException();
    }

    public Task<Astronaut> UpdateAstronaut(Astronaut astronaut)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAstronaut(Guid id)
    {
        throw new NotImplementedException();
    }
}