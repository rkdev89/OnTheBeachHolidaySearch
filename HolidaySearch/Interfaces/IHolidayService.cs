namespace HolidaySearch.Interfaces;
public interface IHolidayService
{
    public IEnumerable<Flight> FindBestFlight(HolidaySearch request, string flightsFilePath);
}
