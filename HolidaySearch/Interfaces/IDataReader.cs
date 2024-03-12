namespace HolidaySearch.Interfaces;
public interface IDataReader
{
    public IEnumerable<T>? ReadData<T>(string filePath);
}
