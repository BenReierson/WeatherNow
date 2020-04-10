using System;
using System.Threading.Tasks;
using WeatherNow.Models;
using WeatherNow.Utilities;

namespace WeatherNow.Services
{
    public class WeatherService : IWeatherService
    {
        #region Service Configuration
        //NOTE - Api paths/key are constants here
        //In production I would expect them to be injected via a service or otherwise
        const string ApiBasePath = "https://api.openweathermap.org/data/2.5/";
        const string ApiKey = "4121c93a545a6709ee42264dc3ab5cf5";
        const string OneCallServicePath = "onecall";

        struct OneCallServiceArgs
        {
            public const string Latitude = "lat=";
            public const string Longitude = "lon=";
            public const string InMetric = "units=metric";
        }
        #endregion

        //defaulting to metric for simplicity
        static string LocationArgs(double latitude, double longitude)
            => $"{OneCallServiceArgs.Latitude}{latitude}&{OneCallServiceArgs.Longitude}{longitude}&{OneCallServiceArgs.InMetric}";

        static string ApiKeyArg(string apiKey) => $"APPID={apiKey}";

        public static string WeatherForLocationUrl(double latitude, double longitude)
            => $"{ApiBasePath}{OneCallServicePath}?{ApiKeyArg(ApiKey)}&{LocationArgs(latitude, longitude)}";


        readonly IRequestProvider requestProvider;

        public WeatherService(IRequestProvider requestProvider)
        {
            this.requestProvider = requestProvider;
        }

        public async Task<LocationWeather?> GetWeatherForLocation(double latitude, double longitude)
        {
            try
            {
                return await requestProvider.GetAsync<LocationWeather>(WeatherForLocationUrl(latitude, longitude));
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
