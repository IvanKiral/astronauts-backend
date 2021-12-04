using API.DTO;

namespace API.Repository;

public class InMemoryAstronautRepository: IAstronautRepository
{
    private readonly Dictionary<Guid, Astronaut> _database = new();

    public async IAsyncEnumerable<Astronaut> GetAllAstronauts()
    {
        foreach (var astronaut in _database.Values)
        {
            yield return await Task.FromResult(astronaut);
        }
    }

    public async Task<Astronaut> AddAstronaut(Astronaut astronaut)
    {
        if (_database.ContainsKey(astronaut.Id))
        {
            throw new ArgumentException("The object with same ID already exists in the database");
        }
        
        _database.Add(astronaut.Id, astronaut);

        return await Task.FromResult(astronaut);
    }

    public async Task<Astronaut> UpdateAstronaut(Astronaut astronaut)
    {
        if (!_database.ContainsKey(astronaut.Id))
        {
            throw new ArgumentException("The object with given ID does not exist in the database");
        }

        _database[astronaut.Id] = astronaut;
        
        return await Task.FromResult(astronaut);
    }

    public async Task DeleteAstronaut(Guid id)
    {
        if (!_database.ContainsKey(id))
        {
            throw new ArgumentException("The object with given ID does not exist in the database");
        }

        await Task.FromResult(_database.Remove(id));
    }
}