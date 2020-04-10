using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WeatherNow.Models;
using WeatherNow.Services;
using WeatherNow.ViewModels;

namespace WeatherNow.UnitTests.ViewModelTests
{
    public class MainViewModelTests
    {
        MainViewModel vm;
        Mock<IWeatherService> mockWeatherService;
        Mock<ILocationService> mockLocationService;

        [SetUp]
        public void Setup()
        {
            mockWeatherService = new Mock<IWeatherService>();
            mockLocationService = new Mock<ILocationService>();

            vm = new MainViewModel(mockWeatherService.Object, mockLocationService.Object);
        }

        [Test]
        public async Task RefreshCurrentWeather_Success()
        {
            double lat = 0;
            double lon = 0;
            var expectedWeather = new LocationWeather();

            mockLocationService.Setup(s => s.GetCurrentLocation())
                               .ReturnsAsync((lat, lon));

            mockWeatherService.Setup(s => s.GetWeatherForLocation(lat, lon))
                              .ReturnsAsync(expectedWeather, TimeSpan.FromMilliseconds(50));

            Assert.IsFalse(vm.IsBusy);
            Assert.IsNull(vm.CurrentWeather);

            var refreshTask = vm.RefreshCurrentWeatherCommand.ExecuteAsync();

            Assert.IsTrue(vm.IsBusy, "Should be busy while fetching weather.");

            await refreshTask;

            mockLocationService.Verify(s => s.GetCurrentLocation(), Times.Once);
            mockLocationService.VerifyNoOtherCalls();

            mockWeatherService.Verify(s => s.GetWeatherForLocation(lat, lon), Times.Once);
            mockWeatherService.VerifyNoOtherCalls();

            Assert.IsFalse(vm.IsBusy);
            Assert.AreEqual(expectedWeather, vm.CurrentWeather);
            Assert.IsEmpty(vm.Error);
        }

        [Test]
        public async Task RefreshCurrentWeather_Error()
        {
            var expectedError = "mock error";

            mockLocationService.Setup(s => s.GetCurrentLocation())
                               .ThrowsAsync(new Exception(expectedError));

            await vm.RefreshCurrentWeatherCommand.ExecuteAsync();

            mockLocationService.Verify(s => s.GetCurrentLocation(), Times.Once);
            mockLocationService.VerifyNoOtherCalls();

            mockWeatherService.VerifyNoOtherCalls();

            Assert.AreEqual(expectedError, vm.Error);
        }
    }
}
