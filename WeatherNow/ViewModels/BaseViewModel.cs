using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherNow.ViewModels
{
    public abstract class BaseViewModel : MvvmHelpers.BaseViewModel
    {
        public BaseViewModel()
        {
        }

        #pragma warning disable CS1998 //Virtual methods with no await
        public virtual async Task OnAppearing() { }
        public virtual async Task OnDisappearing() { }
        #pragma warning restore CS1998

    }
}
