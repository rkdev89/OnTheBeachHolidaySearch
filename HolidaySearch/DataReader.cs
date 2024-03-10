using Newtonsoft.Json;

namespace HolidaySearch;
public class DataReader
{
    public static IEnumerable<Flight>? ReadFlightData(string filePath)
    {        
        if(!FileExists(filePath)) throw new FileNotFoundException();
        return ReadJsonFile<IEnumerable<Flight>>(filePath) ?? [];
    }

    public static IEnumerable<Hotel>? ReadHotelData(string filePath)
    {
        if (!FileExists(filePath)) throw new FileNotFoundException();
        return ReadJsonFile<IEnumerable<Hotel>>(filePath) ?? [];
    }

    public static T? ReadJsonFile<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return string.IsNullOrEmpty(json) ? default : JsonConvert.DeserializeObject<T>(json);
    }

    private static bool FileExists(string filePath) => File.Exists(filePath);
}
