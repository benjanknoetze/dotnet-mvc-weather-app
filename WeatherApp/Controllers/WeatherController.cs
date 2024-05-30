using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers;

public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;
    private const string ApiKey = "fc2cfb7abb8142b695d154951242705";

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetWeather(string location, string region, string country, bool isCelsius)
    {
        try
        {
            var searchQuery = $"{location},{region},{country}";
            var weather = await _weatherService.GetWeatherAsync(searchQuery, ApiKey, isCelsius); ;
            ViewData["IsCelsius"] = isCelsius;
            return PartialView("~/Views/Weather/_WeatherPartial.cshtml", weather);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving weather data: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}
