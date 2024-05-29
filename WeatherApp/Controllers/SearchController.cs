using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly WeatherService _weatherService;
        private const string ApiKey = "fc2cfb7abb8142b695d154951242705";

        public SearchController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            var results = await _weatherService.GetLocationSuggestionsAsync(query, ApiKey);
            return Ok(results);
        }
    }
