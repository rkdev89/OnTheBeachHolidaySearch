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

    [Test]
    public void ReadFlightData_ShouldReturnFlightDataList()
    {
        // Arrange & Act
        var reader = DataReader.ReadFlightData(_dummyFilePath);

        // Assert
        Assert.That(reader, Is.Not.Null);
        Assert.That(reader, Is.Not.Empty);
    }

    [Test]
    public void ReadFlightData_WhenJsonFileMissing_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var reader = new DataReader();

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => DataReader.ReadFlightData(_invalidPath));
    }

    [Test]
    public void ReadFlightData_WhenJsonFileEmpty_ShouldReturnEmptyCollection()
    {
        // Arrange & Act
        var reader = DataReader.ReadFlightData(_emptyFilePath);

        //Assert
        Assert.That(reader, Is.Empty);
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
            }
        ]";
    }
}