using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Masstransit.Common;

public static class CustomConfigurationExtensions
{
    /// <summary>
    /// Should be using on every UsingRabbitMq configuration
    /// </summary>
    /// <param name="configurator"></param>
    public static void ApplyCustomBusConfiguration(this IBusFactoryConfigurator configurator)
    {
        var entityNameFormatter = configurator.MessageTopology.EntityNameFormatter;

        configurator.MessageTopology.SetEntityNameFormatter(new CustomEntityNameFormatter(entityNameFormatter));
    }

    /// <summary>
    /// Should be used on every AddMassTransit configuration
    /// </summary>
    /// <param name="configurator"></param>
    public static void ApplyCustomMassTransitConfiguration(this IBusRegistrationConfigurator configurator)
    {
        configurator.SetEndpointNameFormatter(new CustomEndpointNameFormatter());
    }

    public static IServiceCollection UseMasstransitDefault(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.ApplyCustomMassTransitConfiguration();
            var entryAssembly = Assembly.GetEntryAssembly();
                
            x.AddActivities(entryAssembly);
            x.AddConsumers(entryAssembly);
            

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ApplyCustomBusConfiguration();
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}