using WebApp.Api.Extensions;

namespace WebApp.Api
{
    public static class HostingExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder) 
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            services.AddMediatRConfig(configuration);
            services.AddServices(configuration);
            services.AddOptions(configuration);

            return builder;
        }
    }
}
