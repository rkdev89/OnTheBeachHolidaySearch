using Newtonsoft.Json;

namespace HolidaySearch;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonProperty(PropertyName ="arrival_date")]
    public string ArrivalDate { get; set; }
    public int PricePerNight { get; set; }

    [JsonProperty(PropertyName = "local_airports")]
    public IEnumerable<string> LocalAirports { get; set; }
    public int Nights { get; set; }
}
