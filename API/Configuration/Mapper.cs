using AutoMapper;

namespace API.Configuration;

public static class Mapper
{
    public static IMapper GetMapperInstance() => MapperCreator
        .CreateConfiguration()
        .CreateMapper();
}