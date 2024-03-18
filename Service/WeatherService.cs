
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.JSInterop;

using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherRest.ApiHelper;
using WeatherRest.Data;

using WeatherRest.Models;
using WeatherRest.Service;

namespace WeatherRest.Service
{
    public class WeatherService: IWeatherService
    {


        private readonly WeatherApiDbContext _context;
        public WeatherService(WeatherApiDbContext context)
        {
            _context = context;
        }
        public async Task<string> SaveWeatherDetailsAsync(WeatherCorrectionInfo weatherDetails)
        {
            try
            {
                weatherDetails.RecordedAt = DateTime.Now;
                _context.WeatherCorrectionInfos.Add(weatherDetails);
                await _context.SaveChangesAsync();
                return "Data imported successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing customers: {ex.Message}");
                return "Error importing customers";
                throw;
            }
        }
        public async Task<IEnumerable<WeatherCorrectionInfo>> GetWeatherHistoryAsync()
        {
            try
            {

                return await _context.WeatherCorrectionInfos.ToListAsync();
            }
            catch (Exception ex)
            {
  
                Console.WriteLine($"An error occurred while fetching weather history: {ex.Message}");
                throw;
            }
        }
        public async Task<WeatherCorrectionInfo> GetWeatherHistoryAsync(string name)
        {
            try
            {
    
                return await _context.WeatherCorrectionInfos.FirstOrDefaultAsync(x => x.Name.Equals(name));
            }
            catch (Exception ex)
            {
 
                Console.WriteLine($"An error occurred while fetching weather history: {ex.Message}");
                throw;
            }
        }
    }



}
