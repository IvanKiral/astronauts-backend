using API.DTO;
using API.Models;
using AstronautDao = API.DAO.Astronaut;

namespace Test.Unit.Helpers;

public static class AstronautHelpers
{
    public static Astronaut FirstAstronaut = new()
    {
        Id = Guid.NewGuid(),
        Name = "Name1",
        Surname = "Surname1",
        Birthday = DateTime.Now,
        Ability = "Ability1"
    };
    
    public static Astronaut SecondAstronaut = new()
    {
        Id = Guid.NewGuid(),
        Name = "Name2",
        Surname = "Surname2",
        Birthday = DateTime.Now,
        Ability = "Ability2"
    };
    
    public static Astronaut MissingAstronaut = new()
    {
        Id = Guid.NewGuid(),
        Name = "Name3",
        Surname = "Surname3",
        Birthday = DateTime.Now,
        Ability = "Ability3"
    };

    public static AstronautRequestModel ToAstronautRequest(this Astronaut astronautDto) => new()
    {
        Name = astronautDto.Name,
        Surname = astronautDto.Surname,
        Ability = astronautDto.Ability,
        Birthday = astronautDto.Birthday
    };
    
    public static AstronautResponseModel ToAstronautResponse(this Astronaut astronaut) => 
        new() 
        {
            Id = astronaut.Id,
            Name = astronaut.Name,
            Surname = astronaut.Surname,
            Birthday = astronaut.Birthday,
            Ability = astronaut.Ability
        };

    public static AddAstronaut ToAddAstronaut(this Astronaut astronaut) => 
        new() 
        {
            Name = astronaut.Name,
            Surname = astronaut.Surname,
            Birthday = astronaut.Birthday,
            Ability = astronaut.Ability
        };
    
    public static AstronautAllResponseModel ToAstronautAllResponse(IEnumerable<Astronaut> astronauts) => 
        new() 
        {
            Astroanuts = astronauts.Select(ToAstronautResponse)
        };
    
    public static async IAsyncEnumerable<Astronaut> GetAstronautDtosAsync()
    {
        yield return FirstAstronaut;
        await Task.Delay(200);
        yield return SecondAstronaut;
    }
    
    public static async IAsyncEnumerable<AstronautDao> GetAstronautDaosAsync()
    {
        yield return ToAstronautDao(FirstAstronaut);
        await Task.Delay(200);
        yield return ToAstronautDao(SecondAstronaut);;
    }

    public static AstronautDao ToAstronautDao(this Astronaut astronautDto) => new()
    {
        Id = astronautDto.Id,
        Pk = astronautDto.Id,
        Name = astronautDto.Name,
        Surname = astronautDto.Surname,
        Ability = astronautDto.Ability,
        Birthday = astronautDto.Birthday
    };
    

}