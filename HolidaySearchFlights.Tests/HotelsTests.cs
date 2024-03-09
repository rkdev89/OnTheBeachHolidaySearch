using HolidaySearch;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class HotelsTests
{
    //private string _emptyFilePath;
    //private string _testData;

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
    public void ReadHotelData_ShouldReturnHotelDataList()
    {
        // Arrange & Act
        var actual = DataReader.ReadHotelData(_dummyFilePath);

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
        // Arrange & Act
        var reader = DataReader.ReadHotelData(_emptyFilePath);

        //Assert
        Assert.That(reader, Is.Empty);
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
              }
        ]";
    }
}