using Newtonsoft.Json;
using System.Reflection;

namespace HolidaySearch;
public class DataReader
{
    private readonly string _flightsFilePath;
    private readonly string _hotelsFilePath;

    public DataReader()
    {
        var assemblyDirectory = GetFileDirectoryInfo();
        _flightsFilePath = Path.Combine(assemblyDirectory, Constants.DATA_DIRECTORY, Constants.FLIGHTS_FILE_NAME);
        _hotelsFilePath = Path.Combine(assemblyDirectory, Constants.DATA_DIRECTORY, Constants.HOTELS_FILE_NAME);
    }

    public List<Flight> ReadFlightData()
    {
        return ReadJsonFile<List<Flight>>(_flightsFilePath);
    }

    public List<Hotel> ReadHotelData()
    {
        return ReadJsonFile<List<Hotel>>(_hotelsFilePath);
    }

    private static T ReadJsonFile<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }

    private static string GetFileDirectoryInfo()
    {
        var directory = Assembly.GetExecutingAssembly().Location;
        return Path.GetDirectoryName(directory);
    }
}
