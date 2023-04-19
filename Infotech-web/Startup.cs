using Infotech_web.Models;
using Infotech_web.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Infotech_web
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
        
            services.AddSignalR();
            

            //services.AddSingleton(provider =>
            //    new EntityDbContextFactory(provider.GetRequiredService<DbContextOptions<EntityDbContext>>()));

            services.AddSingleton(provider =>
            {
               
                var dbContextFactory = new EntityDbContextFactory(Configuration);
                var hubContext = provider.GetService<IHubContext<RealtimeChartHub>>();
                var hub = new RealtimeChartHub();
                var dataPointGen =  new DataPointGenerator(hubContext,Configuration);
                return dbContextFactory;
            });
            //services.AddSingleton<DataPointGenerator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<RealtimeChartHub>("/chartHub");
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "revenue",
                    pattern: "api/revenue",
                    defaults: new { controller = "Revenue", action = "Index" });
                endpoints.MapFallbackToFile("index.html");
            });
            

            //app.Run();
        }
    }

}
