namespace HolidaySearch;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ArrivalDate { get; set; }
    public decimal PricePerNight { get; set; }
    public IEnumerable<string> LocalAirports { get; set; }
    public int Nights { get; set; }
}
