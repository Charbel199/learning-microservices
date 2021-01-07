using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GithubService.Jobs;
using GithubService.Repositories;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GithubService
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
            services.AddControllers();
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseDefaultTypeSerializer()
                    .UseMemoryStorage());
            services.AddHangfireServer();
            
            services.AddScoped<IGithubProjectsJob, GithubProjectsJob>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddDbContext<ProjectContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("ProjectConnection")));
            services.AddCors();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider,
            IConfiguration config,
            ProjectContext projectContext)
        {
            projectContext.Database.Migrate();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Should change it
            app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());//ONLY FOR DEV
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


            app.UseHangfireDashboard();
            recurringJobManager.AddOrUpdate(
                "Github Projects",
                () => serviceProvider.GetService<IGithubProjectsJob>().GetProjects(),
                config["GithubJob:Scheduler:FetchProjectsChrono"]);
        }
    }
}