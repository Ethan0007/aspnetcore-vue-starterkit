using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using server.Helpers;

namespace server.Configurations
{
    public class SpaRouting : StartupConfig
    {

        public SpaRouting(IHostingEnvironment env, IConfiguration config) : base(env, config) { }

        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client/dist";
            });

            return null;
        }

        public override void Configure(IApplicationBuilder app)
        {

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseDefaultFiles();

            app.UseSpa(spa =>
            {
                if (Env.IsDevelopment())
                {
                    spa.Options.SourcePath = "wwwroot";
                    app.Run(async (context) =>
                    {
                        context.Response.ContentType = "text/html";
                        await context.Response.SendFileAsync("wwwroot/index.html");
                    });
                }
                else
                {
                    spa.Options.SourcePath = "wwwroot";
                    app.Run(async (context) =>
                    {
                        context.Response.ContentType = "text/html";
                        await context.Response.SendFileAsync(Path.Combine(Env.WebRootPath, "index.html"));
                    });
                }
            });

        }
    }
}