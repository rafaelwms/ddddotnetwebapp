using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastEntity>> GetForecastForecastsAsync(int total);
    }
}
