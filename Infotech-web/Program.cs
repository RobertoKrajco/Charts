using Infotech_web.Models;
using Infotech_web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Infotech_web;
using Microsoft.Extensions.Hosting;


namespace Infotech_web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Set up your web host to use your custom Startup class
                    webBuilder.UseStartup<Startup>();
                });
    }
}
