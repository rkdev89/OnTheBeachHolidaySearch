using Newtonsoft.Json;

namespace HolidaySearch;
public class Flight
{
    public int Id { get; set; }
    public string Airline { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public decimal Price { get; set; }

    [JsonProperty(PropertyName ="departure_date")]
    public string DepartureDate { get; set; }
}
