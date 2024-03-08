using HolidaySearch;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class HotelsTests

{
    [SetUp]
    public void Setup()
    {
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
}