using System;
using echarging.Areas.Identity.Data;
using echarging.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(echarging.Areas.Identity.IdentityHostingStartup))]
namespace echarging.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<echargingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("echargingContextConnection")));

                services.AddDefaultIdentity<echargingUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<echargingContext>();
            });
        }
    }
}