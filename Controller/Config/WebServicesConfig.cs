using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
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
        public static void AddWebServiceConfig(this IServiceCollection services, string corsPolicy)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vehicle.Api", Version = "v1" });
            });
        }
    }
}

