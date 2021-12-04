using AstronautDao = API.DAO.Astronaut;
using AstronautDto = API.DTO.Astronaut;
using static Test.Unit.Helpers.AstronautHelpers;
using API.Repository;
using API.Utils;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Mapper = API.Configuration.Mapper;

namespace Test.Unit;

public class AstronautRepositoryTest
{
    private IAsyncEnumerable<AstronautDao> _astronauts = GetAstronautDaosAsync();
    private IMapper _mapper = Mapper.GetMapperInstance();
    private AstronautDao MissingAstronautDao = ToAstronautDao(MissingAstronaut);

    [Fact]
    public async void GetAllAstronauts_ReturnsAllAstronauts()
    {
        var cosmosRepository = Substitute.For<ICosmosRepository<AstronautDao>>();
        cosmosRepository.GetAll().Returns(_astronauts);
        var repository = new AstronautRepository(cosmosRepository, _mapper);
            
        var result = await repository.GetAllAstronauts().ToListAsync();
            
        result.Should().BeEquivalentTo(new List<AstronautDto> {FirstAstronaut, SecondAstronaut});
    }
    
    [Fact]
    public async void AddAstronaut_ReturnsAstronaut()
    {
        var cosmosRepository = Substitute.For<ICosmosRepository<AstronautDao>>();
        cosmosRepository.Add(Arg.Is<AstronautDao>(a => a.Name == MissingAstronautDao.Name))
            .Returns(MissingAstronautDao);
        var repository = new AstronautRepository(cosmosRepository, _mapper);
            
        var result = await repository.AddAstronaut(MissingAstronaut);
            
        result.Should().BeEquivalentTo(MissingAstronaut);
    }
    
    [Fact]
    public async void UpdateAstronaut_ReturnsAstronaut()
    {
        var cosmosRepository = Substitute.For<ICosmosRepository<AstronautDao>>();
        var resultAstronaut = AstronautUtils.MakeAstronaut(SecondAstronaut.Id, ToAddAstronaut(MissingAstronaut));
        cosmosRepository.Update(SecondAstronaut.Id, Arg.Is<AstronautDao>(a => a.Name == MissingAstronautDao.Name))
            .Returns(ToAstronautDao(resultAstronaut));
        var repository = new AstronautRepository(cosmosRepository, _mapper);
            
        var result = await repository.UpdateAstronaut(resultAstronaut);
            
        result.Should().BeEquivalentTo(resultAstronaut);
    }
    
    [Fact]
    public async void DeleteAstronaut_Ok()
    {
        var cosmosRepository = Substitute.For<ICosmosRepository<AstronautDao>>();
        cosmosRepository.Delete(SecondAstronaut.Id)
            .Returns(Task.FromResult(ToAstronautDao(SecondAstronaut)));
        var repository = new AstronautRepository(cosmosRepository, _mapper);
            
        await repository.DeleteAstronaut(SecondAstronaut.Id);
    }
}