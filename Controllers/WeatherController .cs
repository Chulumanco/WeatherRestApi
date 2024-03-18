using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherRest.Models;
using WeatherRest.Service;

namespace WeatherRest.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherController> _logger;
        public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }
        [HttpPost("saveweather")]
        public async Task<IActionResult> SaveWeather([FromBody] WeatherCorrectionInfo weatherDetails)
        {
            if (weatherDetails == null)
            {
                return BadRequest("Enter Required information");
            }

            try
            {
                var result = await _weatherService.SaveWeatherDetailsAsync(weatherDetails);

                if (result.StartsWith("Error"))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                return Ok("Ok");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while saving weather details: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<WeatherCorrectionInfo>>> GetWeatherHistory()
        {
            try
            {
             
                var weatherHistory = await _weatherService.GetWeatherHistoryAsync();

                return Ok(weatherHistory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching weather history: {ex.Message}");
            }
        }

    }
}
