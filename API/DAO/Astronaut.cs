using Newtonsoft.Json;

namespace API.DAO;

public class Astronaut
{
    [JsonProperty(PropertyName = "partitionKey")]
    public Guid Pk { get; set; }
    
    [JsonProperty(PropertyName = "id")]   
    public Guid Id { get; init; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public string Ability { get; set; }
}