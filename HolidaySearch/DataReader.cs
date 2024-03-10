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
        if (string.IsNullOrEmpty(json)) return default;
        if(!JsonSchemaValidator.IsValidJson(json)) throw new Exception("Invalid json schema");

        var settings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-dd"
        };

        var result = JsonConvert.DeserializeObject<T>(json, settings);
        return result;
    }

    private static bool FileExists(string filePath) => File.Exists(filePath);
}
