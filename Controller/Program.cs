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
        var configuration = builder.Configuration;
        var corsPolicy = "CORSPolicy";

        builder.Services.AddControllers();
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
        services.AddWebServiceConfig();

        var app = builder.Build();

        app.AddWebApplicationConfig();

        app.Run();


    }
}