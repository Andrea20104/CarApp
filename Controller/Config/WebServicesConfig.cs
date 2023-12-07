using Microsoft.OpenApi.Models;

namespace Api.Config
{
    public static class WebServicesConfig
    {
        /// <summary>
        /// Adds the Web service collection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="corsPolicy">The CorsPolicy.</param>
        /// <returns>IServiceCollection.</returns>
        public static void AddWebServiceConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });
        }
    }
}

