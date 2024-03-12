using HolidaySearch.Interfaces;
using Newtonsoft.Json;

namespace HolidaySearch;
public class DataReader : IDataReader
{
    public IEnumerable<T>? ReadData<T>(string filePath) => ReadJsonFile<IEnumerable<T>>(filePath) ?? [];

    private static bool FileExists(string filePath) => File.Exists(filePath);

    public static T? ReadJsonFile<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        if (string.IsNullOrEmpty(json)) return default;
        if (!FileExists(filePath)) throw new FileNotFoundException();
        if(!JsonSchemaValidator.IsValidJson(json)) throw new Exception("Invalid json schema");

        var result = JsonConvert.DeserializeObject<T>(json);
        return result;
    }
}
