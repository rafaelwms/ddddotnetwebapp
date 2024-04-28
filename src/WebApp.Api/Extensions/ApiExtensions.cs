using System.Reflection;
using WebApp.Application.UseCases.WeatherForecast;
using WebApp.Domain.Interfaces.Services;
using WebApp.Domain.Options;
using WebApp.Infraestructure.Services;

namespace WebApp.Api.Extensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddMediatRConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                cfg.RegisterServicesFromAssemblies(typeof(WeatherForecastCommand).GetTypeInfo().Assembly);
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SummaryOptions>(configuration.GetSection(SummaryOptions.EntryName));

            return services;
        }

    }
}
