using System;
using WeatherNow.Services;
using WeatherNow.Utilities;
using WeatherNow.ViewModels;
using WeatherNow.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherNow
{
    public partial class App : Application
    {
        public enum Theme { Light, Dark }
        static Theme _currentTheme = Theme.Dark;
        public static Theme CurrentTheme
        {
            get => _currentTheme;
            set
            {
                Console.WriteLine("Setting Theme " + value.ToString());
                if (_currentTheme != value)
                {
                    _currentTheme = value;

                    Current.Resources.MergedDictionaries.Clear();
                    switch (value)
                    {
                        case Theme.Dark:
                            Current.Resources.MergedDictionaries.Add(new DarkTheme());
                            break;
                        case Theme.Light:
                        default:
                            Current.Resources.MergedDictionaries.Add(new LightTheme());
                            break;
                    }
                }
            }
        }

        public App()
        {
            InitializeComponent();

            //TODO: Register services with IOC container

            MainPage = new ContentPage(); //placeholder to be replaced in OnStart
        }

        protected override void OnStart()
        {
            if (AppInfo.RequestedTheme == AppTheme.Light) CurrentTheme = Theme.Light;

            //NOTE - Normally services and VMs would be created via IOC container
            var mainVm = new MainViewModel(new WeatherService(new HttpRequestProvider()), new LocationService());
            MainPage = new MainPage(mainVm);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
