using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using Microsoft.Extensions.DependencyInjection;
using WebBase.Data;
using Microsoft.AspNetCore.Identity;
using WebBase.Areas.Identity.Data;

namespace WebBase
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await CreateDbIfNotExists(host);

            host.Run();
        }

        private static async Task CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);                   
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context2 = services.GetRequiredService<UsersRolesDB>();
                UserManager<TAUser> um = services.GetRequiredService<UserManager<TAUser>>();
                //dependency injection for this is missing
                RoleManager<IdentityRole> rm = services.GetRequiredService<RoleManager<IdentityRole>>();
                await UsersDbInitializer.Initialize(context2, um, rm);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
