using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotEBookWeb.Data;

[assembly: HostingStartup(typeof(NotEBookWeb.Areas.Identity.IdentityHostingStartup))]
namespace NotEBookWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NotEBookWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NotEBookWebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<NotEBookWebContext>();
            });
        }
    }
}