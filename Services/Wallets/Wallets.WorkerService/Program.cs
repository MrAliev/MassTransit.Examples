using Masstransit.Common;
using Microsoft.EntityFrameworkCore;
using Wallet.Serivces;
using Wallets.Data;
using Wallets.Service.Contracts;

namespace Wallets.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddTransient<IWalletsRepository, WalletsRepository>();
            builder.Services.AddDbContext<WalletsDbContext>(options => options.UseInMemoryDatabase("WalletsInMemoryDb"));
            builder.Services.UseMasstransitDefault();

            var host = builder.Build();
            host.Run();
        }
    }
}