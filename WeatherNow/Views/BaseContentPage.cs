using System;
using WeatherNow.ViewModels;
using Xamarin.Forms;

namespace WeatherNow.Views
{
    public class BaseContentPage<T> : ContentPage where T : BaseViewModel
    {
        public BaseContentPage(T viewModel) => BindingContext = viewModel;

        public T? ViewModel => BindingContext as T;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel?.OnDisappearing();
        }
    }
}
