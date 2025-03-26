using CDNConverter.API.Infrastructure.DataAccess;
using CDNConverter.API.Shared.Comunication;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace CDNConverter.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<AppDbContext>();
                    if (db.Database.GetPendingMigrations().Any())
                    {
                        db.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ResourceResponseMessages.MIGRATIONS_ERROR);
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
