using WeatherRest.Models;

namespace WeatherRest.Service
{
    public interface IWeatherService
    {

        Task<string> SaveWeatherDetailsAsync(WeatherCorrectionInfo weatherDetails);
        Task<IEnumerable<WeatherCorrectionInfo>> GetWeatherHistoryAsync();
        Task<WeatherCorrectionInfo> GetWeatherHistoryAsync(string name);

    }
}
