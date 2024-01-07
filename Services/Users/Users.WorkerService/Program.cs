using Masstransit.Common;
using Microsoft.EntityFrameworkCore;
using Users.Data;
using Users.Services;
using Users.Services.Contracts;

namespace Users.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddTransient<IUsersRepository, UsersRepository>();
            builder.Services.AddDbContext<UsersDbContext>(options => options.UseInMemoryDatabase("UsersInMemoryDb"));
            builder.Services.UseMasstransitDefault();

            //builder.Services.AddMassTransit(x =>
            //{
            //    x.ApplyCustomMassTransitConfiguration();
            //    var entryAssembly = Assembly.GetEntryAssembly();
                
            //    x.AddActivities(entryAssembly);

            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        cfg.Host("localhost", "/", h =>
            //        {
            //            h.Username("guest");
            //            h.Password("guest");
            //        });

            //        cfg.ApplyCustomBusConfiguration();
            //        cfg.ConfigureEndpoints(context);
            //    });
            //});

            var host = builder.Build();
            host.Run();
        }
    }
}