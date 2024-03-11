using NUnit.Framework;
using NUnit.Framework.Internal;

namespace HolidaySearch.Tests;

[TestFixture]
public class SearchHolidayTests
{
    private const string FLIGHTS_FILE_PATH = "FlightDummyData.json";
    private const string HOTELS_FILE_PATH = "HotelsDummyData.json";

    //[Test]
    //public void SearchHoliday_ExampleTestCase1_ReturnsFlight2AndHotel9()
    //{
    //    var holiday = new Holiday(FLIGHTS_FILE_PATH, HOTELS_FILE_PATH);

    //    var search = new HolidaySearch()
    //    {
    //       DepartingFrom = "MAN",
    //       TravellingTo = "AGP",
    //       DepartureDate = "2023-07-01",
    //       Duration = 7
    //    };

    //    // Act
    //    var result = holiday.FindClosestMatch(search);
    //    var (flightId, hotelId) = result.FirstOrDefault();


    //    // Assert
    //    Assert.NotNull(result);
    //    Assert.IsInstanceOf<IEnumerable<(int flightId, int hotelId)>>(result);        
    //    Assert.AreEqual(2, flightId);
    //    Assert.AreEqual(9, hotelId);
    //}

    //[Test]
    //public void SearchHoliday_ExampleTestCase2_ReturnsFlight6AndHotel5()
    //{
    //    var holiday = new Holiday(FLIGHTS_FILE_PATH, HOTELS_FILE_PATH);

    //    var search = new HolidaySearch()
    //    {
    //        DepartingFrom = "LGW",
    //        TravellingTo = "PMI",
    //        DepartureDate = "2023-06-15",
    //        Duration = 10
    //    };

    //    // Act
    //    var result = holiday.FindClosestMatch(search);
    //    var (flightId, hotelId) = result.FirstOrDefault();


    //    // Assert
    //    Assert.NotNull(result);
    //    Assert.IsInstanceOf<IEnumerable<(int flightId, int hotelId)>>(result);
    //    Assert.AreEqual(6, flightId);
    //    Assert.AreEqual(5, hotelId);
    //}

    [Test]
    public void SearchHoliday_FindBestFlightCustomerOne_ReturnsBestValueFlight() 
    {
        //Arrange
        var holiday = new Holiday();
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "AGP",
            DepartureDate = DateTime.Parse("2023-07-01"),
            Duration = 7
        };
        //Act
       var result = holiday.FindBestFlight(request,"FlightDummyData.json").FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestHotelCustomerOne_ReturnsBestValueHotel()
    {
        //Arrange
        var holiday = new Holiday();
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "AGP",
            DepartureDate = DateTime.Parse("2023-07-01"),
            Duration = 7
        };
        //Act
        var result = holiday.FindBestHotel(request, "HotelsDummyData.json").FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(9, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestFlightCustomerTwo_ReturnsBestValueFlight()
    {
        //Arrange
        var holiday = new Holiday();
        var request = new HolidaySearch()
        {
            DepartingFrom = "LGW",
            TravellingTo = "PMI",
            DepartureDate = DateTime.Parse("2023-06-15"),
            Duration = 10
        };
        //Act
        var result = holiday.FindBestFlight(request, "FlightDummyData.json").FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestHotelCustomerTwo_ReturnsBestValueHotel()
    {
        //Arrange
        var holiday = new Holiday();
        var request = new HolidaySearch()
        {
            DepartingFrom = "LGW",
            TravellingTo = "PMI",
            DepartureDate = DateTime.Parse("2023-06-15"),
            Duration = 10
        };
        //Act
        var result = holiday.FindBestHotel(request, "HotelsDummyData.json").FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(5, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestFlightCustomerThree_ReturnsBestValueFlight()
    {
        //Arrange
        var holiday = new Holiday();
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "LPA",
            DepartureDate = DateTime.Parse("2022-11-10"),
            Duration = 14
        };
        //Act
        var result = holiday.FindBestFlight(request, "FlightDummyData.json").FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(7, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestHotelCustomerThree_ReturnsBestValueHotel()
    {
        //Arrange
        var holiday = new Holiday();
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "LPA",
            DepartureDate = DateTime.Parse("2022-11-10"),
            Duration = 14
        };
        //Act
        var result = holiday.FindBestHotel(request, "HotelsDummyData.json").FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Id);
    }

}

