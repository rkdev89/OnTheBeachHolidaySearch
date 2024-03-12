using HolidaySearch.Interfaces;

namespace HolidaySearch;
public class HolidayService : IHolidayService
{
    public IEnumerable<Flight> FindBestFlight(HolidaySearch request, string flightsFilePath)
    {
        var reader = new DataReader();
        var flights = reader.ReadData<Flight>(flightsFilePath);

        var sortedFlights = flights
            .OrderBy(f => CalculateFlightPriority(f, request))
            .ThenBy(f => f.Price);

        return sortedFlights;
    }

    private static int CalculateFlightPriority(Flight flight, HolidaySearch request)
    {
        var priorityMap = new Dictionary<Func<bool>, int>
        {
            { () => flight.From == request.DepartingFrom && flight.DepartureDate.Date == request.DepartureDate.Date, 0 },
            { () => flight.To == request.TravellingTo, 1 },
            { () => flight.From == request.DepartingFrom, 2 }
        };

        foreach (var kvp in priorityMap)
        {
            if (kvp.Key())
                return kvp.Value;
        }

        return 3;
    }

    public IEnumerable<Hotel> FindBestHotel(HolidaySearch request, string hotelsFilePath)
    {
        var reader = new DataReader();
        var hotels = reader.ReadData<Hotel>(hotelsFilePath);

        var result = hotels.Where(h =>
            (string.IsNullOrEmpty(request.TravellingTo) || h.LocalAirports.Contains(request.TravellingTo)) &&
            (request.Duration == 0 || h.Nights == request.Duration) &&
            (request.DepartureDate == default || (h.ArrivalDate.Date == request.DepartureDate.Date)))
            .OrderBy(p => p.PricePerNight * request.Duration);

        if (!result.Any())
        {
            result = hotels.OrderBy(h =>
            {
                int matchCount = 0;

                if (!string.IsNullOrEmpty(request.TravellingTo) && h.LocalAirports.Contains(request.TravellingTo))
                    matchCount++;
                if (request.Duration != 0 && h.Nights == request.Duration)
                    matchCount++;
                if (request.DepartureDate != default && h.ArrivalDate.Date == request.DepartureDate.Date)
                    matchCount++;

                return matchCount;
            }).ThenBy(p => p.PricePerNight * request.Duration);
        }

        return result;
    }

    public (IEnumerable<Flight>, IEnumerable<Hotel>) BestValuePackage(HolidaySearch request, string flightsFilePath, string hotelsFilePath)
    {
        var bestFlight = FindBestFlight(request, flightsFilePath);
        var bestHotel = FindBestHotel(request, hotelsFilePath);
        return (bestFlight, bestHotel);
    }
}
