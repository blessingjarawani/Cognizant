using Cognizant.DAL.Contexts;
using Cognizant.DAL.ExternalSoure.ApiClients;
using Cognizant.DAL.ExternalSoure.ApiClients.Abstracts;
using Cognizant.DAL.Repositories;
using Cognizant.DAL.Repositories.Abstracts;
using Cognizant.Infrastructure.Shared.Responses.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Cognizant.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDbContexts(services);
            RegisterServices(services);
            RegisterRepositories(services);
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        private void RegisterDbContexts(IServiceCollection services)
        {
            services.AddDbContext<ProgrammingTasksContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProgrammingTasks")));
           
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<IProgrammingLanguagesRepository, ProgrammingLanguagesRepository>();
            services.AddScoped<IGameStatsRepository, GameStatsRepository>();
        }
        private void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(IBaseResponse).GetTypeInfo().Assembly);
            services.AddScoped<IJdoodleClient, JdoodleClient>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
