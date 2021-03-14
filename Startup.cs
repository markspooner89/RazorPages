using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Code.Data;
using Code.Services;

namespace Code
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(options => 
            {
                options.RootDirectory = "/Code/Pages";
            });

            services.AddScoped<IJsonFileHelper, JsonFileHelper>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICacheHelper, CacheHelper>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IArticleService, ArtliceService>();
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
