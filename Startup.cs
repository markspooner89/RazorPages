using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPageApp.Repositories;
using RazorPageApp.Repositories.Interfaces;
using RazorPageApp.Services;
using RazorPageApp.Services.Interfaces;

namespace RazorPageApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddScoped<IJsonFileHelper, JsonFileHelper>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<ICacheHelper, CacheHelper>();
            services.AddScoped<IGradeService, GradeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
