using NUnit.Framework.Internal;

namespace HolidaySearch.Tests;

[TestFixture]
public class SearchHolidayTests
{
    private const string FLIGHTS_FILE_PATH = "Data\\FlightDummyData.json";
    private const string HOTELS_FILE_PATH = "Data\\HotelsDummyData.json";
    private readonly DataReader _reader = new DataReader();

    [Test]
    public void SearchHoliday_FindBestFlightCustomerOne_ReturnsBestValueFlight() 
    {
        //Arrange
        var holidayService = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "AGP",
            DepartureDate = DateTime.Parse("2023-07-01"),
            Duration = 7
        };
        //Act
       var result = holidayService.FindBestFlight(request, FLIGHTS_FILE_PATH).FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestHotelCustomerOne_ReturnsBestValueHotel()
    {
        //Arrange
        var holidayService = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "AGP",
            DepartureDate = DateTime.Parse("2023-07-01"),
            Duration = 7
        };
        //Act
        var result = holidayService.FindBestHotel(request, HOTELS_FILE_PATH).FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(9, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestFlightCustomerTwo_ReturnsBestValueFlight()
    {
        //Arrange
        var holidayService = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "LGW",
            TravellingTo = "PMI",
            DepartureDate = DateTime.Parse("2023-06-15"),
            Duration = 10
        };
        //Act
        var result = holidayService.FindBestFlight(request, FLIGHTS_FILE_PATH).FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestHotelCustomerTwo_ReturnsBestValueHotel()
    {
        //Arrange
        var holidayService = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "LGW",
            TravellingTo = "PMI",
            DepartureDate = DateTime.Parse("2023-06-15"),
            Duration = 10
        };
        //Act
        var result = holidayService.FindBestHotel(request, HOTELS_FILE_PATH).FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(5, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestFlightCustomerThree_ReturnsBestValueFlight()
    {
        //Arrange
        var holiday = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "LPA",
            DepartureDate = DateTime.Parse("2022-11-10"),
            Duration = 14
        };
        //Act
        var result = holiday.FindBestFlight(request, FLIGHTS_FILE_PATH).FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(7, result.Id);
    }

    [Test]
    public void SearchHoliday_FindBestHotelCustomerThree_ReturnsBestValueHotel()
    {
        //Arrange
        var holidayService = new HolidayService(_reader);

        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "LPA",
            DepartureDate = DateTime.Parse("2022-11-10"),
            Duration = 14
        };
        //Act
        var result = holidayService.FindBestHotel(request, HOTELS_FILE_PATH).FirstOrDefault();

        //Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(6, result.Id);
    }

    [Test]
    public void CombineFlightAndHotel_CombineCustomerOneRequestResults_ReturnsBestValuePackage()
    {
        //Arrange
        var holiday = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravellingTo = "AGP",
            DepartureDate = DateTime.Parse("2023-07-01"),
            Duration = 7
        };

        //Act
        var (bestFlight, bestHotel) = holiday.BestValuePackage(request, FLIGHTS_FILE_PATH, HOTELS_FILE_PATH);

        Assert.IsNotNull(bestFlight);
        Assert.IsNotNull(bestHotel);
        Assert.AreEqual(2, bestFlight.FirstOrDefault().Id);
        Assert.AreEqual(9, bestHotel.FirstOrDefault().Id);
    }

    [Test]
    public void CombineFlightAndHotel_CombineCustomerTwoRequestResults_ReturnsBestValuePackage()
    {
        //Arrange
        var holiday = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "LGW",
            TravellingTo = "PMI",
            DepartureDate = DateTime.Parse("2023-06-15"),
            Duration = 10
        };

        //Act
        var (bestFlight, bestHotel) = holiday.BestValuePackage(request, FLIGHTS_FILE_PATH, HOTELS_FILE_PATH);

        Assert.IsNotNull(bestFlight);
        Assert.IsNotNull(bestHotel);
        Assert.AreEqual(6, bestFlight.FirstOrDefault().Id);
        Assert.AreEqual(5, bestHotel.FirstOrDefault().Id);

    }

    [Test]
    public void CombineFlightAndHotel_CombineCustomerThreeRequestResults_ReturnsBestValuePackage()
    {
        //Arrange
        var holiday = new HolidayService(_reader);
        var request = new HolidaySearch()
        {
            DepartingFrom = "LGW",
            TravellingTo = "LPA",
            DepartureDate = DateTime.Parse("2022-11-10"),
            Duration = 14
        };

        //Act
        var (bestFlight, bestHotel) = holiday.BestValuePackage(request, FLIGHTS_FILE_PATH, HOTELS_FILE_PATH);

        Assert.IsNotNull(bestFlight);
        Assert.IsNotNull(bestHotel);
        Assert.AreEqual(7, bestFlight.FirstOrDefault().Id);
        Assert.AreEqual(6, bestHotel.FirstOrDefault().Id);
    }
}