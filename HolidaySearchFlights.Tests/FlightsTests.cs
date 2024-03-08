using HolidaySearch;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class FlightsTests
{
    [SetUp]
    public void Setup()
    {
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
}