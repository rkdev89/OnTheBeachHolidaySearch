using HolidaySearch;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class FlightsTests
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
        if(File.Exists(_emptyFilePath)) File.Delete(_emptyFilePath);
        if(File.Exists(_dummyFilePath)) File.Delete(_dummyFilePath);
    }

    [Test]
    public void ReadFlightData_ShouldReturnFlightDataList()
    {
        // Arrange & Act
        var reader = new DataReader();
        var result = reader.ReadData<Flight>(_dummyFilePath);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public void ReadFlightData_WhenJsonFileMissing_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var reader = new DataReader();

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => reader.ReadData<Flight>(_invalidPath));
    }

    [Test]
    public void ReadFlightData_WhenJsonFileEmpty_ShouldReturnEmptyCollection()
    {
        // Arrange
        var reader = new DataReader();

        //Act
        var result = reader.ReadData<Flight>(_emptyFilePath);

        //Assert
        Assert.That(result, Is.Empty);
    }

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

    private static string TestData()
    {
        return @"[
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
          },
          {
            ""id"": 3,
            ""airline"": ""Trans American Airlines"",
            ""from"": ""MAN"",
            ""to"": ""PMI"",
            ""price"": 170,
            ""departure_date"": ""2023-06-15""
          },
          {
            ""id"": 4,
            ""airline"": ""Trans American Airlines"",
            ""from"": ""LTN"",
            ""to"": ""PMI"",
            ""price"": 153,
            ""departure_date"": ""2023-06-15""
          },
          {
            ""id"": 5,
            ""airline"": ""Fresh Airways"",
            ""from"": ""MAN"",
            ""to"": ""PMI"",
            ""price"": 130,
            ""departure_date"": ""2023-06-15""
          },
          {
            ""id"": 6,
            ""airline"": ""Fresh Airways"",
            ""from"": ""LGW"",
            ""to"": ""PMI"",
            ""price"": 75,
            ""departure_date"": ""2023-06-15""
          },
          {
            ""id"": 7,
            ""airline"": ""Trans American Airlines"",
            ""from"": ""MAN"",
            ""to"": ""LPA"",
            ""price"": 125,
            ""departure_date"": ""2022-11-10""
          },
          {
            ""id"": 8,
            ""airline"": ""Fresh Airways"",
            ""from"": ""MAN"",
            ""to"": ""LPA"",
            ""price"": 175,
            ""departure_date"": ""2023-11-10""
          },
          {
            ""id"": 9,
            ""airline"": ""Fresh Airways"",
            ""from"": ""MAN"",
            ""to"": ""AGP"",
            ""price"": 140,
            ""departure_date"": ""2023-04-11""
          },
          {
            ""id"": 10,
            ""airline"": ""First Class Air"",
            ""from"": ""LGW"",
            ""to"": ""AGP"",
            ""price"": 225,
            ""departure_date"": ""2023-07-01""
          },
          {
            ""id"": 11,
            ""airline"": ""First Class Air"",
            ""from"": ""LGW"",
            ""to"": ""AGP"",
            ""price"": 155,
            ""departure_date"": ""2023-07-01""
          },
          {
            ""id"": 12,
            ""airline"": ""Trans American Airlines"",
            ""from"": ""MAN"",
            ""to"": ""AGP"",
            ""price"": 202,
            ""departure_date"": ""2023-10-25""
          }
        ]";
    }
}