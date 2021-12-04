using API.Configuration.Profiles;
using AutoMapper;

namespace API.Configuration;

public static class MapperCreator
{
    public static MapperConfiguration CreateConfiguration() =>
        new(mc =>
        {
            mc.AddProfile<AstronautProfile>();
        });
}