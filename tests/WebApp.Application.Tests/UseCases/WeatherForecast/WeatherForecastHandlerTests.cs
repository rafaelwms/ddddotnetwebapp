using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using WebApp.Application.UseCases.WeatherForecast;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Services;
using Xunit;

namespace WebApp.Application.Tests.UseCases.WeatherForecast
{
    public class WeatherForecastHandlerTests
    {

        private readonly Mock<IWeatherForecastService> _weatherForecastService = new Mock<IWeatherForecastService>();
        private readonly Mock<ILogger<WeatherForecastHandle>> _logger = new Mock<ILogger<WeatherForecastHandle>>();
        private readonly WeatherForecastHandle _handler;
        private IEnumerable<WeatherForecastEntity> _forecasts;

        public WeatherForecastHandlerTests()
        {

            _forecasts = new List<WeatherForecastEntity>
            {
                new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 30, Summary = "Hot" },
                new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 20, Summary = "Hot" },
                new WeatherForecastEntity { Date = DateOnly.FromDateTime(DateTime.Now), TemperatureC = 20, Summary = "Hot" },
            };

            _handler = new WeatherForecastHandle(_logger.Object, _weatherForecastService.Object);
        }

        // Add tests here

        [Fact]
        public async Task GetForecastsOK()
        {
            // Arrange
            var total = 5;


            _weatherForecastService.Setup(x => x.GetForecastForecastsAsync(total)).ReturnsAsync(_forecasts);

            // Act
            var result = await _handler.Handle(new WeatherForecastCommand { Total = total }, CancellationToken.None);

            // Assert
            Assert.Equals(_forecasts, result.Forecasts);
        }

    }
}
