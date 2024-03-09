using HolidaySearch;
using System.Runtime.CompilerServices;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class HotelsTests
{
    private string _emptyFilePath;

    [SetUp]
    public void Setup()
    {
        _emptyFilePath = Path.GetTempFileName();
        File.WriteAllText(_emptyFilePath, "");
    }

    [Test]
    public void ReadHotelData_ShouldReturnHotelDataList()
    {
        // Arrange
        var reader = new DataReader();

        // Act
        var actual = reader.ReadHotelData();

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
        Assert.Throws<FileNotFoundException>(() => reader.ReadJsonFile<string>(_emptyFilePath));
    }
}