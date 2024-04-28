using System;
using WebApp.Domain.Entities;

namespace WebApp.Application.UseCases.WeatherForecast
{
    public class WeatherForecastResponse
    {
        public IEnumerable<WeatherForecastEntity> Forecasts { get; set; }
    }
}
