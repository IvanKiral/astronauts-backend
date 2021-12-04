using API.Utils;
using Newtonsoft.Json;

namespace API.Models;

public class AstronautResponseModel
{
    public Guid Id { get; init; }
    
    public string Name { get; init; }
    
    public string Surname { get; init; }
    
    public DateTime Birthday { get; init; }
    
    public string Ability { get; init; }
}