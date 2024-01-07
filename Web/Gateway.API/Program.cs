using Accounts.Services.Contracts;
using Gateway.API.Services;
using Masstransit.Common;
using Users.Services.Contracts;
using Wallets.Service.Contracts;

namespace Gateway.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.UseMasstransitDefault();
            builder.Services.AddTransient<IUsersService, UsersService>();
            builder.Services.AddTransient<IWalletsService, WalletsService>();
            builder.Services.AddTransient<IAccountsService, AccountsService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
