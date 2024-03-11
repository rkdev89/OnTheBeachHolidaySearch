﻿namespace HolidaySearch;
public class Holiday
{
    private readonly string _flightsFilePath;
    //private readonly string _hotelsFilePath;

    //public Holiday(string flightsFilePath)
    //{
    //    _flightsFilePath = flightsFilePath;
    //   // _hotelsFilePath = hotelsFilePath;
    //}

    public IEnumerable<Flight> FindBestFlight(HolidaySearch request, string flightsFilePath)
    {
        var flights = DataReader.ReadFlightData(flightsFilePath);

        var result = flights.Where(f =>
            f.From == request.DepartingFrom &&
            f.To == request.TravellingTo &&
            f.DepartureDate ==  request.DepartureDate).OrderBy(f => f.Price);

        return result;
    }

    public IEnumerable<Hotel> FindBestHotel(HolidaySearch request, string hotelsFilePath)
    {
        var hotels = DataReader.ReadHotelData(hotelsFilePath);
        var result = hotels.Where(h =>
                     h.LocalAirports.Contains(request.TravellingTo) &&
                     h.Nights == request.Duration &&
                     h.ArrivalDate == request.DepartureDate).OrderBy(p => p.PricePerNight * request.Duration);
        return result;
    }

    public (IEnumerable<Flight>, IEnumerable<Hotel>) BestValuePackage(HolidaySearch request, string flightsFilePath, string hotelsFilePath)
    {
        var bestFlight = FindBestFlight(request, flightsFilePath);
        var bestHotel = FindBestHotel(request, hotelsFilePath);
        return (bestFlight, bestHotel);
    }


    //public IEnumerable<(int flightId, int hotelId)> FindClosestMatch(HolidaySearch search)
    //{
    //    var flights = DataReader.ReadFlightData(_flightsFilePath);
    //    var hotels = DataReader.ReadHotelData(_hotelsFilePath);

    //    if (flights == null || hotels == null)
    //        throw new Exception("No flight or hotel data available");

    //    var endDate = DateTime.Parse(search.DepartureDate).AddDays(search.Duration);

    //    var closestOptions = from flight in flights
    //                         from hotel in hotels
    //                         where flight.From == search.DepartingFrom &&
    //                               flight.To == search.TravellingTo &&
    //                               flight.DepartureDate == DateTime.Parse(search.DepartureDate) &&
    //                               flight.DepartureDate.AddDays(search.Duration) <= flight.DepartureDate.AddDays(7) &&
    //                               hotel.LocalAirports.Contains(flight.To) &&
    //                               DateTime.Parse(hotel.ArrivalDate) >= flight.DepartureDate &&
    //                               DateTime.Parse(hotel.ArrivalDate) <= flight.DepartureDate.AddDays(7)
    //                         orderby Math.Abs((DateTime.Parse(search.DepartureDate) - flight.DepartureDate).TotalDays)
    //                         select (flight.Id, hotel.Id);
    //    return closestOptions;
    //}
}
