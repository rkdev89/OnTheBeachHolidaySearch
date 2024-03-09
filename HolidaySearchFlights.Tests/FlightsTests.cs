using HolidaySearch;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class FlightsTests
{
    private string _emptyFilePath;

    [SetUp]
    public void Setup()
    {
        _emptyFilePath = Path.GetTempFileName();
        File.WriteAllText(_emptyFilePath, "");
    }

    [Test]
    public void ReadFlightData_ShouldReturnFlightDataList()
    {
        // Arrange
        var reader = new DataReader();

        // Act
        var actual = reader.ReadFlightData();

        // Assert
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.Not.Empty);
    }

    [Test]
    public void ReadFlightData_WhenJsonFileMissing_ShouldThrowFileNotFoundException()
    {
        // Arrange
        var reader = new DataReader();

        // Act & Assert
        Assert.Throws<FileNotFoundException>(() => reader.ReadJsonFile<string>(_emptyFilePath));
    }
}