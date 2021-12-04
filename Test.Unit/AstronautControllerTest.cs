using API.Controllers;
using AutoMapper;
using API.DTO;
using AstronautDao = API.DAO.Astronaut;
using API.Services;
using API.Utils;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;
using Test.Unit.Helpers;
using static Test.Unit.Helpers.AstronautHelpers;
using Mapper = API.Configuration.Mapper;

namespace Test.Unit;

public class AstronautControllerTest
{
    private readonly IMapper _mapper = Mapper.GetMapperInstance();
    
    private static readonly IAsyncEnumerable<Astronaut> Astronauts = GetAstronautDtosAsync();
    
    [Fact]
    public async void GetAstronauts_ReturnsAstroanuts()
    {
        var service = Substitute.For<IAstronautService>();
        service.GetALlAstronauts().Returns(Astronauts);
        var controller = new AstronautController(service, _mapper);
            
        var result = await controller.GetAstronauts();

        var expectedAstronauts = await Astronauts.ToListAsync();
        var expectedResponse = ToAstronautAllResponse(expectedAstronauts);

        result.Value.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async void AddAstronaut_ReturnsAstronaut()
    {
        var service = Substitute.For<IAstronautService>();
        service.AddAstronaut(Arg.Is<AddAstronaut>(a => a.Name == MissingAstronaut.Name))
            .Returns(AstronautHelpers.MissingAstronaut);
        var controller = new AstronautController(service, _mapper);
        
        var requestModel = MissingAstronaut.ToAstronautRequest();
        var result = await controller.CreateAstronaut(requestModel);
        var expectedResult = MissingAstronaut.ToAstronautResponse();

        result.Value.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async void AddAstronaut_ReturnsBadRequest()
    {
        var service = Substitute.For<IAstronautService>();
        service.AddAstronaut(Arg.Is<AddAstronaut>(a => a.Name == MissingAstronaut.Name))
            .Throws<ArgumentException>();
        var controller = new AstronautController(service, _mapper);
        
        var requestModel = MissingAstronaut.ToAstronautRequest();
        var result = await controller.CreateAstronaut(requestModel);

        result.Result.Should().BeOfType<BadRequestResult>();
    }
    
    
    [Fact]
    public async void UpdateAstronaut_ReturnsAstronaut()
    {
        var service = Substitute.For<IAstronautService>();
        var serviceResultAstronaut = AstronautUtils.MakeAstronaut(
            SecondAstronaut.Id,
            MissingAstronaut.ToAddAstronaut()
        );
        service.UpdateAstronaut(SecondAstronaut.Id,
                Arg.Is<AddAstronaut>(a => a.Name == MissingAstronaut.Name))
            .Returns(serviceResultAstronaut);
        var controller = new AstronautController(service, _mapper);
        
        var requestModel = MissingAstronaut.ToAstronautRequest();
        var result = await controller.UpdateAstronaut(SecondAstronaut.Id, requestModel);
        var expectedResult = serviceResultAstronaut.ToAstronautResponse();

        result.Value.Should().BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async void UpdateAstronaut_ReturnsBadRequest()
    {
        var service = Substitute.For<IAstronautService>();
        service.UpdateAstronaut(MissingAstronaut.Id, Arg.Is<AddAstronaut>(a => a.Name == MissingAstronaut.Name))
            .Throws<ArgumentException>();
        var controller = new AstronautController(service, _mapper);
        
        var requestModel = MissingAstronaut.ToAstronautRequest();
        var result = await controller.UpdateAstronaut(MissingAstronaut.Id, requestModel);

        result.Result.Should().BeOfType<BadRequestResult>();
    }
    
    [Fact]
    public async void DeleteAstronaut_ReturnsOk()
    {
        var service = Substitute.For<IAstronautService>();
        var controller = new AstronautController(service, _mapper);

        var result = await controller.DeleteAstronaut(SecondAstronaut.Id);

        result.Should().BeOfType<OkResult>();
    }
    
    [Fact]
    public async void DeleteAstronaut_ReturnsBadRequest()
    {
        var service = Substitute.For<IAstronautService>();
        service.DeleteAstronaut(MissingAstronaut.Id).Throws<ArgumentException>();
        var controller = new AstronautController(service, _mapper);
        
        var result = await controller.DeleteAstronaut(MissingAstronaut.Id);

        result.Should().BeOfType<BadRequestResult>();
    }
}