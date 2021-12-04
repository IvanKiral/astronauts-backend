using AstronautDao = API.DAO.Astronaut;
using AutoMapper;
using AstronautDTO = API.DTO.Astronaut;

namespace API.Repository;

public class AstronautRepository: IAstronautRepository
{
    private ICosmosRepository<AstronautDao> _repository;
    private IMapper _mapper;

    public AstronautRepository(ICosmosRepository<AstronautDao> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public IAsyncEnumerable<AstronautDTO> GetAllAstronauts()
    {
        return _repository.GetAll().Select(_mapper.Map<AstronautDTO>);
    }

    public async Task<AstronautDTO> AddAstronaut(AstronautDTO astronaut)
    {
        var newAstronaut = _mapper.Map<AstronautDao>(astronaut);
        var resultAstronaut = await _repository.Add(newAstronaut);

        return _mapper.Map<AstronautDTO>(resultAstronaut);
    }

    public async Task<AstronautDTO> UpdateAstronaut(AstronautDTO astronaut)
    {
        var updateAstronaut = _mapper.Map<AstronautDao>(astronaut);
        var resultAstronaut = await _repository.Update(astronaut.Id, updateAstronaut);

        return _mapper.Map<AstronautDTO>(resultAstronaut);
    }

    public async Task DeleteAstronaut(Guid id)
    {
        await _repository.Delete(id);
    }
}