using MediatR;
using Microsoft.Extensions.Logging;
using WebApp.Domain.Interfaces.Services;


namespace WebApp.Application.UseCases.WeatherForecast
{
    public class WeatherForecastHandle : IRequestHandler<WeatherForecastCommand, WeatherForecastResponse>
    {
        ILogger _logger;
        IWeatherForecastService _weatherForecastService;

        public WeatherForecastHandle(ILogger<WeatherForecastHandle> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }
        public async Task<WeatherForecastResponse> Handle(WeatherForecastCommand request, CancellationToken cancellationToken)
        {

            try 
            {
                var total = request.Total;
                _logger.LogInformation($"[WeatherForecastHandle.Handle] - Getting {total} Forecasts.");
                var result = await _weatherForecastService.GetForecastForecastsAsync(total);
                return new WeatherForecastResponse { Forecasts = result };
            }
            catch (Exception ex)
            {
                _logger.LogError($"[WeatherForecastHandle.Handle] - Generic Error: {ex.Message}.");
                throw;
            }
        }

    }
}
