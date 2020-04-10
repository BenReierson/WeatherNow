using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WeatherNow.Models;
using WeatherNow.Services;
using WeatherNow.Utilities;

namespace WeatherNow.UnitTests.ServiceTests
{
    [TestFixture]
    public class WeatherServiceTests
    {
        WeatherService service;
        Mock<IRequestProvider> mockRequestProvider;

        [SetUp]
        public void Setup()
        {
            mockRequestProvider = new Mock<IRequestProvider>();
            service = new WeatherService(mockRequestProvider.Object);
        }

        [Test]
        public async Task GetWeatherForLocation()
        {
            double lat = 0;
            double lon = 0;
            var expectedUrl = WeatherService.WeatherForLocationUrl(lat, lon);

            var expectedResult = new LocationWeather();

            mockRequestProvider.Setup(s => s.GetAsync<LocationWeather>(expectedUrl))
                               .ReturnsAsync(expectedResult);

            var result = await service.GetWeatherForLocation(0, 0);

            mockRequestProvider.Verify(s => s.GetAsync<LocationWeather>(expectedUrl), Times.Once);
            mockRequestProvider.VerifyNoOtherCalls();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
