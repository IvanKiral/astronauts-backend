using API.DTO;
using API.Repository;
using API.Services;
using API.Utils;
using FluentAssertions;
using NSubstitute;
using Xunit;
using static Test.Unit.Helpers.AstronautHelpers;

namespace Test.Unit;

public class AstronautServiceTest
{

    private static readonly IAsyncEnumerable<Astronaut> Astronauts = GetAstronautDtosAsync();

    [Fact]
    public async void GetAllAstronauts_ReturnsAstronauts()
    {
        var repository = Substitute.For<IAstronautRepository>();
        repository.GetAllAstronauts().Returns(Astronauts);
        var service = new AstronautService(repository);

        var result = await service.GetALlAstronauts().ToListAsync();
        var expectedResult = await Astronauts.ToListAsync();
        
        result.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async void AddAstronaut_ReturnsAstronaut()
    {
        var repository = Substitute.For<IAstronautRepository>();
        repository.AddAstronaut(Arg.Is<Astronaut>(a => a.Name == MissingAstronaut.Name)).Returns(MissingAstronaut);
        var service = new AstronautService(repository);

        var result = await service.AddAstronaut(ToAddAstronaut(MissingAstronaut));
        
        result.Should().BeEquivalentTo(MissingAstronaut);
    }
    
    [Fact]
    public async void UpdateAstronaut_ReturnsAstronaut()
    {
        var repository = Substitute.For<IAstronautRepository>();
        var resultAstronaut = AstronautUtils.MakeAstronaut(SecondAstronaut.Id, ToAddAstronaut(MissingAstronaut));
        repository.UpdateAstronaut(Arg.Is<Astronaut>(a => a.Name == MissingAstronaut.Name)).Returns(resultAstronaut);
        var service = new AstronautService(repository);

        var result = await service.UpdateAstronaut(SecondAstronaut.Id, ToAddAstronaut(MissingAstronaut));
        
        result.Should().BeEquivalentTo(resultAstronaut);
    }
    
    [Fact]
    public async void DeleteAstronaut_Ok()
    {
        var repository = Substitute.For<IAstronautRepository>();
        var service = new AstronautService(repository);

        await service.DeleteAstronaut(SecondAstronaut.Id);
    }
}