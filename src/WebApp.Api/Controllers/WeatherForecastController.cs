using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.UseCases.WeatherForecast;
using WebApp.Domain.Entities;


namespace WebApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("get", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecastEntity> Get(int total)
        {
            var comm = new WeatherForecastCommand { Total = total };

            var result = _mediator.Send(comm).Result;

            return result.Forecasts;
        }
    }
}
