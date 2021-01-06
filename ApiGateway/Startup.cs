using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGateway.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway
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
            services.AddOcelot(Configuration);
            
            //For authentication
            var identityBuilder = services.AddAuthentication();
            IdentityServerConfig identityServerConfig = new IdentityServerConfig();
            Configuration.Bind("IdentityServerConfig", identityServerConfig);
            if (identityServerConfig != null && identityServerConfig.Resources != null)
            {
                foreach (var resource in identityServerConfig.Resources)
                {
                    identityBuilder.AddIdentityServerAuthentication(resource.Key, options => 
                    {
                        options.Authority = $"http://{identityServerConfig.IP}:{identityServerConfig.Port}";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = resource.Name;
                        options.SupportedTokens = SupportedTokens.Both;
                    });
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            await app.UseOcelot();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Should change it
            app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());//ONLY FOR DEV
            
            //Authentication
            app.UseAuthentication();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}