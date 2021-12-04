using API.DTO;
using API.Repository;
using API.Utils;

namespace API.Services;

public class AstronautService: IAstronautService
{
    private readonly IAstronautRepository _repository;
    
    public AstronautService(IAstronautRepository repository)
    {
        _repository = repository;
    }

    public IAsyncEnumerable<Astronaut> GetALlAstronauts() => _repository.GetAllAstronauts();

    public async Task<Astronaut> AddAstronaut(AddAstronaut astronaut)
    {
        var newAstronaut = AstronautUtils.MakeAstronaut(astronaut);

        return await _repository.AddAstronaut(newAstronaut);
    }

    public async Task<Astronaut> UpdateAstronaut(Astronaut astronaut)
    {
        return await _repository.UpdateAstronaut(astronaut);
    }

    public async Task DeleteAstronaut(Guid id) => await _repository.DeleteAstronaut(id);
}