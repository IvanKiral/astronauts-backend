using API.DTO;

namespace API.Utils;

public static class AstronautUtils
{
    public static Astronaut MakeAstronaut(AddAstronaut astronaut) => new()
    {
        Id = Guid.NewGuid(),
        Name = astronaut.Name,
        Surname = astronaut.Surname,
        Birthday = astronaut.Birthday,
        Ability = astronaut.Ability
    };
}