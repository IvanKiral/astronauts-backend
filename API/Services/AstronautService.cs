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
        var newAstronaut = AstronautUtils.MakeAstronaut(Guid.NewGuid(), astronaut);

        return await _repository.AddAstronaut(newAstronaut);
    }

    public async Task<Astronaut> UpdateAstronaut(Guid id, AddAstronaut astronaut)
    {
        var updateAstronaut = AstronautUtils.MakeAstronaut(id, astronaut);
        
        return await _repository.UpdateAstronaut(updateAstronaut);
    }

    public async Task DeleteAstronaut(Guid id) => await _repository.DeleteAstronaut(id);
}