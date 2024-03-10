using HolidaySearch.Schemas;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace HolidaySearch;
public static class JsonSchemaValidator
{
    public static bool IsValidJson(string json)
    {
        var flightJsonSchema = JSchema.Parse(FlightJsonSchema.FlightSchema);
        var hotelJsonSchema = JSchema.Parse(HotelJsonSchema.HotelSchema);

        JToken token = JToken.Parse(json);
        return token.IsValid(flightJsonSchema) || token.IsValid(hotelJsonSchema);
    }
}
