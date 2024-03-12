namespace HolidaySearch.Tests;

[TestFixture]
public class JsonValidatorTests
{
    [Test]
    public void ValidateValidFlightJsonFormat_IfValid_ReturnsTrue()
    {
        var validData = @"[
          {
            ""id"": 1,
            ""airline"": ""First Class Air"",
            ""from"": ""MAN"",
            ""to"": ""TFS"",
            ""price"": 470,
            ""departure_date"": ""2023-07-01""
          },
          {
            ""id"": 2,
            ""airline"": ""Oceanic Airlines"",
            ""from"": ""MAN"",
            ""to"": ""AGP"",
            ""price"": 245,
            ""departure_date"": ""2023-07-01""
          }]";

        bool isValid = JsonSchemaValidator.IsValidJson(validData);

        Assert.That(isValid, Is.True);
    }

    [Test]
    public void ValidateInvalidFlightJsonFormat_IfInvalid_ReturnsFalse()
    {
        var validData = @"[
          {
            ""id"": 1,
            ""airline"": ""First Class Air"",
            ""from"": ""MAN"",
            ""to"": ""TFS"",
            ""price"": 470,
            ""departure_date"": ""2023-07-01""
          },
          {
            ""id"": 2,
            ""airline"": ""Oceanic Airlines"",
            ""from"": ""MAN"",
            ""to"": ""AGP"",
            ""price"": ""245"",
            ""departure_date"": ""2023-07-01""
          }]";

        bool isValid = JsonSchemaValidator.IsValidJson(validData);

        Assert.That(isValid, Is.False);
    }

    [Test]
    public void ValidateHotelJsonFormat_IfValid_ReturnsTrue()
    {
        var validData = @"[
          {
            ""id"": 1,
            ""name"": ""Iberostar Grand Portals Nous"",
            ""arrival_date"": ""2022-11-05"",
            ""price_per_night"": 100,
            ""local_airports"": [ ""TFS"" ],
            ""nights"": 7
          },
          {
            ""id"": 2,
            ""name"": ""Laguna Park 2"",
            ""arrival_date"": ""2022-11-05"",
            ""price_per_night"": 50,
            ""local_airports"": [ ""TFS"" ],
            ""nights"": 7
          }]";

        bool isValid = JsonSchemaValidator.IsValidJson(validData);

        Assert.That(isValid, Is.True);
    }

    [Test]
    public void ValidateHotelJsonFormat_IfInvalid_ReturnsFalse()
    {
        var validData = @"[
          {
            ""id"": 1,
            ""name"": ""Iberostar Grand Portals Nous"",
            ""arrival_date"": ""2022-11-05"",
            ""price_per_night"": ""100"",
            ""local_airports"": [ ""TFS"" ],
            ""nights"": 7
          },
          {
            ""id"": 2,
            ""name"": ""Laguna Park 2"",
            ""arrival_date"": ""2022-11-05"",
            ""price_per_night"": 50,
            ""local_airports"": [ ""TFS"" ],
            ""nights"": 7
          }]";

        bool isValid = JsonSchemaValidator.IsValidJson(validData);

        Assert.That(isValid, Is.False);
    }
}
