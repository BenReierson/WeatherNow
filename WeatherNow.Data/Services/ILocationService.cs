using System;
using System.Threading.Tasks;

namespace WeatherNow.Services
{
    public interface ILocationService
    {
        Task<(double Latitude, double Longitude)> GetCurrentLocation();
    }
}
