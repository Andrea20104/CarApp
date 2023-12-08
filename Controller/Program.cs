using Api.Config;
using Api.IoC;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Interfaces;
using Business;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var corsPolicy = "CORSPolicy";

        /// <summary>
        /// Configure host(Log and Autofac)
        /// </summary>
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureContainer<ContainerBuilder>(builder =>
                    {
                        builder.RegisterModule(new ContainerModule());
                    });


        /// <summary>
        /// Configure Services
        /// </summary>
        services.AddWebServiceConfig(corsPolicy);

        var app = builder.Build();
        app.UseCors(corsPolicy);
        app.AddWebApplicationConfig();

        app.Run();


    }
}