namespace HolidaySearch.Schemas;
public class FlightJsonSchema
{
    public const string FlightSchema = @"
        {
            ""$schema"": ""http://json-schema.org/draft-07/schema#"",
            ""type"": ""array"",
            ""items"": {
                ""type"": ""object"",
                ""properties"": {
                    ""id"": { ""type"": ""integer"" },
                    ""airline"": { ""type"": ""string"" },
                    ""from"": { ""type"": ""string"" },
                    ""to"": { ""type"": ""string"" },
                    ""price"": { ""type"": ""number"" },
                    ""departure_date"": { ""type"": ""string"", ""format"": ""date"" }
                },
                ""required"": [""id"", ""airline"", ""from"", ""to"", ""price"", ""departure_date""],
                ""additionalProperties"": false
            }
        }";
}
