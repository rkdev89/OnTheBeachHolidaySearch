using HolidaySearch;
using Newtonsoft.Json;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class Flights
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReadFlightData_ShouldReturnFlightDataList()
    {
        // Arrange
        string json = File.ReadAllText(Constants.FlightsFilePath);
        var expected = JsonConvert.DeserializeObject<List<Flight>>(json);
        var reader = new DataReader();

        // Act
        var actual = reader.ReadFlightData();

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);
    }
}