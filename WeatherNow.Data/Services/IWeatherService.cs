using System;
using System.Threading.Tasks;
using WeatherNow.Models;

namespace WeatherNow.Services
{
    public interface IWeatherService
    {
        Task<LocationWeather?> GetWeatherForLocation(double latitude, double longitude);
    }
}
