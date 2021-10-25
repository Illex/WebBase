using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebBase.Areas.Identity.Data;
using WebBase.Data;

[assembly: HostingStartup(typeof(WebBase.Areas.Identity.IdentityHostingStartup))]
namespace WebBase.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UsersRolesDB>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsersRolesDBConnection")));

                //set email confirmation to false?
                services.AddDefaultIdentity<TAUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<UsersRolesDB>();                

                //tells the system to use roles? breaks system
                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>();
            });
        }
    }
}