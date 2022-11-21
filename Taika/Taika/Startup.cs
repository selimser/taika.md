using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taika.Repository.Repo;
using Taika.Repository.Settings;
using Taika.Repository.Shared;
using Taika.Repository.Storage;
using Taika.Service.Repository;
using Taika.Service.RepositoryService.Repository;
using Taika.Service.Settings;
using Taika.Service.Storage;

namespace Taika
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<ISettingsService, SettingsService>();
            services.AddSingleton<ISettingsRepository, SettingsRepository>();

            services.AddSingleton<IRepoService, RepoService>();
            services.AddSingleton<IRepoRepository, RepoRepository>();

            services.AddSingleton<IStorageService, StorageService>();
            services.AddSingleton<IStorageRepository, StorageRepository>();

            services.AddSingleton<ITaikaUnit, TaikaUnit>();
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
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
