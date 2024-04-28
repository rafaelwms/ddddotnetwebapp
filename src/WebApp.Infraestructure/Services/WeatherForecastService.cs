using Microsoft.Extensions.Options;
using WebApp.Domain.Entities;
using WebApp.Domain.Interfaces.Services;
using WebApp.Domain.Options;

namespace WebApp.Infraestructure.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {

        private readonly SummaryOptions _sumaryOptions;

        public WeatherForecastService(IOptions<SummaryOptions> options)
        {
            _sumaryOptions = options.Value;
        }

        public async Task<IEnumerable<WeatherForecastEntity>> GetForecastForecastsAsync(int total)
        {
            return  Enumerable.Range(1, total).Select(index => new WeatherForecastEntity
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _sumaryOptions.Summaries[Random.Shared.Next(_sumaryOptions.Summaries.Length)]
            }).ToArray();
        }
    }
}
