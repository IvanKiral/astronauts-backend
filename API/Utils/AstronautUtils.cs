using API.DTO;

namespace API.Utils;

public static class AstronautUtils
{
    public static Astronaut MakeAstronaut(Guid id, AddAstronaut astronaut) => new()
    {
        Id = id,
        Name = astronaut.Name,
        Surname = astronaut.Surname,
        Birthday = astronaut.Birthday,
        Ability = astronaut.Ability
    };
}