using HolidaySearch;
using Newtonsoft.Json;

namespace HolidaySearchFlights.Tests;

[TestFixture]
public class Hotels

{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReadHotelData_ShouldReturnHotelDataList()
    {
        // Arrange
        string json = File.ReadAllText(Constants.HotelsFilePath);
        var expected = JsonConvert.DeserializeObject<List<Hotel>>(json);
        var reader = new DataReader();

        // Act
        var actual = reader.ReadHotelData();

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);
    }
}