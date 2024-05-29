using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services;
public class WeatherService
{
    private readonly RestClient _client;

    public WeatherService()
    {
        _client = new RestClient("https://api.weatherapi.com/v1");
    }

    public async Task<WeatherResponse> GetWeatherAsync(string location, string apiKey, bool isCelsius)
    {
        var request = new RestRequest("current.json", Method.Get);
        request.AddParameter("key", apiKey);
        request.AddParameter("q", location);
        request.AddParameter("aqi", "no");

        var response = await _client.ExecuteAsync(request);

        if (response.Content == null)
        {
            Console.WriteLine("No response from Weather API.");
            throw new InvalidOperationException("Failed to retrieve weather data.");
        }

        Console.WriteLine($"Weather API Response: {response.Content}");

        try
        {
            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response.Content);
            if (weatherResponse == null)
            {
                Console.WriteLine("Failed to deserialize weather data.");
                throw new InvalidOperationException("Failed to retrieve weather data.");
            }

            return weatherResponse;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialization error: {ex.Message}");
            throw new InvalidOperationException("Failed to retrieve weather data.");
        }
    }

    public async Task<List<string>> GetLocationSuggestionsAsync(string query, string apiKey)
    {
        var request = new RestRequest("search.json", Method.Get);
        request.AddParameter("key", apiKey);
        request.AddParameter("q", query);

        var response = await _client.ExecuteAsync(request);

        if (response.Content == null)
        {
            Console.WriteLine("No response from Weather API.");
            throw new InvalidOperationException("Failed to retrieve location suggestions.");
        }

        Console.WriteLine($"Weather API Search Response: {response.Content}");

        try
        {
            var suggestions = JsonConvert.DeserializeObject<List<LocationSuggestion>>(response.Content);
            if (suggestions == null)
            {
                Console.WriteLine("Failed to deserialize location suggestions.");
                throw new InvalidOperationException("Failed to retrieve location suggestions.");
            }

            return suggestions.Select(s => s.Name).ToList();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON deserialization error: {ex.Message}");
            throw new InvalidOperationException("Failed to retrieve location suggestions.");
        }
    }
}
