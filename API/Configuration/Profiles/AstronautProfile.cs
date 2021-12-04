using API.DTO;
using API.Models;
using AutoMapper;

namespace API.Configuration.Profiles;

public class AstronautProfile: Profile
{
    public AstronautProfile()
    {
        CreateMap<Astronaut, AstronautResponseModel>();
    }
}