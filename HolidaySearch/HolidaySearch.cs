namespace HolidaySearch;
public class HolidaySearch
{
    public string DepartingFrom { get; set; }
    public string TravellingTo { get; set; }
    public string DepartureDate { get; set; }
    public int Duration { get; set; }

    public HolidaySearch(string departingFrom, string travellingTo, string departureDate, int duration)
    {
        DepartingFrom = departingFrom;
        TravellingTo = travellingTo;
        DepartureDate = departureDate;
        Duration = duration;
    }

    public HolidaySearch()
    {
    }
}
