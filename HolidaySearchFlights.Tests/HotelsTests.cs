using HolidaySearch;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class HotelsTests
{
    private string _emptyFilePath;
    private string _dummyFilePath;
    private string _dummyData;
    private readonly string _invalidPath = "nothingHere.json";

    [SetUp]
    public void Setup()
    {
        _emptyFilePath = Path.GetTempFileName();
        File.WriteAllText(_emptyFilePath, "");

        _dummyData = TestData();
        _dummyFilePath = Path.GetTempFileName();

        File.WriteAllText(_dummyFilePath, _dummyData);
    }

    [TearDown]
    public void Teardown()
    {
        if (File.Exists(_emptyFilePath)) File.Delete(_emptyFilePath);
        if (File.Exists(_dummyFilePath)) File.Delete(_dummyFilePath);
    }

    [Test]
    public void ReadHotelData_ShouldReturnHotelDataList()
    {
        // Arrange
        var reader = new DataReader();

        // Act
        var actual = reader.ReadData<Hotel>(_dummyFilePath);

        // Assert
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.Not.Empty);
    }

    [Test]
    public void ReadHotelData_WhenJsonFileMissing_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var reader = new DataReader();

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => DataReader.ReadJsonFile<string>(_invalidPath));
    }

    [Test]
    public void ReadHotelData_WhenJsonFileEmpty_ShouldReturnEmptyCollection()
    {
        // Arrange
        var reader = new DataReader();

        //Act
        var result = reader.ReadData<Flight>(_emptyFilePath);

        //Assert
        Assert.That(result, Is.Empty);
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

    private static string TestData()
    {
        return @"[
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
          },
          {
            ""id"": 3,
            ""name"": ""Sol Katmandu Park & Resort"",
            ""arrival_date"": ""2023-06-15"",
            ""price_per_night"": 59,
            ""local_airports"": [ ""PMI"" ],
            ""nights"": 14
          },
          {
            ""id"": 4,
            ""name"": ""Sol Katmandu Park & Resort"",
            ""arrival_date"": ""2023-06-15"",
            ""price_per_night"": 59,
            ""local_airports"": [ ""PMI"" ],
            ""nights"": 14
          },
          {
            ""id"": 5,
            ""name"": ""Sol Katmandu Park & Resort"",
            ""arrival_date"": ""2023-06-15"",
            ""price_per_night"": 60,
            ""local_airports"": [ ""PMI"" ],
            ""nights"": 10
          },
          {
            ""id"": 6,
            ""name"": ""Club Maspalomas Suites and Spa"",
            ""arrival_date"": ""2022-11-10"",
            ""price_per_night"": 75,
            ""local_airports"": [ ""LPA"" ],
            ""nights"": 14
          },
          {
            ""id"": 7,
            ""name"": ""Club Maspalomas Suites and Spa"",
            ""arrival_date"": ""2022-09-10"",
            ""price_per_night"": 76,
            ""local_airports"": [ ""LPA"" ],
            ""nights"": 14
          },
          {
            ""id"": 8,
            ""name"": ""Boutique Hotel Cordial La Peregrina"",
            ""arrival_date"": ""2022-10-10"",
            ""price_per_night"": 45,
            ""local_airports"": [ ""LPA"" ],
            ""nights"": 7
          },
          {
            ""id"": 9,
            ""name"": ""Nh Malaga"",
            ""arrival_date"": ""2023-07-01"",
            ""price_per_night"": 83,
            ""local_airports"": [ ""AGP"" ],
            ""nights"": 7
          },
          {
            ""id"": 10,
            ""name"": ""Barcelo Malaga"",
            ""arrival_date"": ""2023-07-05"",
            ""price_per_night"": 45,
            ""local_airports"": [ ""AGP"" ],
            ""nights"": 10
          },
          {
            ""id"": 11,
            ""name"": ""Parador De Malaga Gibralfaro"",
            ""arrival_date"": ""2023-10-16"",
            ""price_per_night"": 100,
            ""local_airports"": [ ""AGP"" ],
            ""nights"": 7
          },
          {
            ""id"": 12,
            ""name"": ""MS Maestranza Hotel"",
            ""arrival_date"": ""2023-07-01"",
            ""price_per_night"": 45,
            ""local_airports"": [ ""AGP"" ],
            ""nights"": 14
          },
          {
            ""id"": 13,
            ""name"": ""Jumeirah Port Soller"",
            ""arrival_date"": ""2023-06-15"",
            ""price_per_night"": 295,
            ""local_airports"": [ ""PMI"" ],
            ""nights"": 10
          }
        ]";
    }
}