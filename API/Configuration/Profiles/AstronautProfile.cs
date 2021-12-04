using API.DTO;
using API.Models;
using AutoMapper;
using AstronautDto = API.DTO.Astronaut;
using AstronautDao = API.DAO.Astronaut;

namespace API.Configuration.Profiles;

public class AstronautProfile: Profile
{
    public AstronautProfile()
    {
        CreateMap<AstronautDto, AstronautResponseModel>();
        CreateMap<AstronautRequestModel, AddAstronaut>();
        CreateMap<AstronautDto, AstronautDao>().BeforeMap(
            (source, destinationTask) => destinationTask.Pk = source.Id);
        CreateMap<AstronautDao, AstronautDto>();

    }
}