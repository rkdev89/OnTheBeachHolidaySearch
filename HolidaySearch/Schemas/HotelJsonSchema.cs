namespace HolidaySearch.Schemas;
public class HotelJsonSchema
{
    public const string HotelSchema = @"
    {
        ""$schema"": ""http://json-schema.org/draft-07/schema#"",
        ""type"": ""array"",
        ""items"": {
            ""type"": ""object"",
            ""properties"": {
                ""id"": { ""type"": ""integer"" },
                ""name"": { ""type"": ""string"" },
                ""arrival_date"": { ""type"": ""string"", ""format"": ""date"" },
                ""price_per_night"": { ""type"": ""number"" },
                ""local_airports"": {
                    ""type"": ""array"",
                    ""items"": { ""type"": ""string"" },
                    ""minItems"": 1
                },
                ""nights"": { ""type"": ""integer"" }
            },
            ""required"": [""id"", ""name"", ""arrival_date"", ""price_per_night"", ""local_airports"", ""nights""],
            ""additionalProperties"": false
        }
    }";
}
