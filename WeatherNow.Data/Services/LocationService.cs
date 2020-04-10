using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherNow.Services
{
    public class LocationService : ILocationService
    {
        public async Task<(double Latitude, double Longitude)> GetCurrentLocation()
        {
            try
            {
                if (await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>() == PermissionStatus.Granted)
                {
                    var location = await Geolocation.GetLocationAsync();
                    return (location.Latitude, location.Longitude);
                }
                else throw new ApiException("Location unavailable");
            }
            //NOTE - Logging and other error handling would go here.
            catch (ApiException) { throw; }
            catch (Exception ex)
            {
                var apiEx = new ApiException(ex.Message, ex);
                throw apiEx;
            }
        }
    }
}
