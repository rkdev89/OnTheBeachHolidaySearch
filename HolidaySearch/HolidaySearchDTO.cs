namespace HolidaySearch;
public class HolidaySearchDTO
{
    public string DepartingFrom { get; set; }
    public string TravellingTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }

    public HolidaySearchDTO(string departingFrom, string travellingTo, DateTime departureDate, int duration)
    {
        DepartingFrom = departingFrom;
        TravellingTo = travellingTo;
        DepartureDate = departureDate;
        Duration = duration;
    }

    public HolidaySearchDTO()
    {
    }
}
