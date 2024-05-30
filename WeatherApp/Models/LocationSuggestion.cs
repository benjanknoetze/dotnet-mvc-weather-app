namespace WeatherApp.Models;

public class LocationSuggestion
{
    public required string Name { get; set; }
    public string? Region { get; set; }
    public required string Country { get; set; }
}
