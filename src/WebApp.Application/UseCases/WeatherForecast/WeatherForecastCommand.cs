using MediatR;


namespace WebApp.Application.UseCases.WeatherForecast
{
    public class WeatherForecastCommand : IRequest<WeatherForecastResponse>
    {
        public int Total { get; set; }
    }
}
