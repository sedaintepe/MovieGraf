using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieGraf.Data;

[assembly: HostingStartup(typeof(MovieGraf.Areas.Identity.IdentityHostingStartup))]
namespace MovieGraf.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MovieGrafContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MovieGrafContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MovieGrafContext>();
            });
        }
    }
}