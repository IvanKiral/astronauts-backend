using Newtonsoft.Json.Converters;

namespace API.Utils;

public class CustomDateTimeConverter: IsoDateTimeConverter
{
    public CustomDateTimeConverter()
    {
        DateTimeFormat = "yyyy-MM-dd";
    }
}