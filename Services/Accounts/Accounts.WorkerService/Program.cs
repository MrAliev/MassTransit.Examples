using Accounts.Services;
using Accounts.Services.Contracts;
using Masstransit.Common;

namespace Accounts.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.UseMasstransitDefault();

            var host = builder.Build();
            host.Run();
        }
    }
}