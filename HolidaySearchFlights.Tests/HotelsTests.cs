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
        Assert.IsNotNull(actual);
        Assert.Greater(actual.Count, 0);
    }
}