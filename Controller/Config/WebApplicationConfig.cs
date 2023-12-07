using System.Dynamic;
using System.Reflection;
using System.Text.Json;

namespace Api.Config
{
    public static class WebApplicationConfig
    {
        public static void AddWebApplicationConfig(this WebApplication? app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
            });

            app.UseRouting();

            app.MapControllers();
        }
    }
}
