using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOBILE_BASED.DAL;
using MOBILE_BASED.DAL.Context;

[assembly: HostingStartup(typeof(MOBILE_BASED.Web.Areas.Identity.IdentityHostingStartup))]
namespace MOBILE_BASED.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}