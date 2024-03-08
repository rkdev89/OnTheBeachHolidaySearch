using Newtonsoft.Json;

namespace HolidaySearch;
public class DataReader
{
    public List<Flight> ReadFlightData()
    {
        string json = File.ReadAllText(Constants.FlightsFilePath);
        //string json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flights.json"));
        return JsonConvert.DeserializeObject<List<Flight>>(json);
    }

    public List<Hotel> ReadHotelData()
    {
        string json = File.ReadAllText(Constants.HotelsFilePath);
        return JsonConvert.DeserializeObject<List<Hotel>>(json);
    }
}
