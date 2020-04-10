using System;
using WeatherNow.Services;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using WeatherNow.Models;

namespace WeatherNow.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly IWeatherService weatherService;
        readonly ILocationService locationService;

        public MainViewModel(IWeatherService weatherService, ILocationService locationService)
        {
            this.weatherService = weatherService;
            this.locationService = locationService;
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();

            await RefreshCurrentWeatherCommand.ExecuteAsync();
        }

        #region Properties

        LocationWeather? _CurrentWeather;
        public LocationWeather? CurrentWeather
        {
            get => _CurrentWeather;
            set => SetProperty(ref _CurrentWeather, value);
        }

        string _Error = string.Empty;
        public string Error
        {
            get => _Error;
            set => SetProperty(ref _Error, value ?? string.Empty);
        }
        #endregion

        #region Commands

        AsyncCommand? _RefreshCurrentWeatherCommand;
        public AsyncCommand RefreshCurrentWeatherCommand => _RefreshCurrentWeatherCommand ??= new AsyncCommand(
            async () =>
            {
                try
                {
                    IsBusy = true;

                    (var latitude, var longitude) = await locationService.GetCurrentLocation();

                    CurrentWeather = await weatherService.GetWeatherForLocation(latitude, longitude);

                    Error = string.Empty;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                }
                finally
                {
                    IsBusy = false;
                }
            });


        AsyncCommand? _ToggleThemeCommand;
        public AsyncCommand ToggleThemeCommand => _ToggleThemeCommand ??= new AsyncCommand(
            async () =>
            {
                App.CurrentTheme = App.CurrentTheme == App.Theme.Light ? App.Theme.Dark : App.Theme.Light;
            });
        #endregion
    }
}
