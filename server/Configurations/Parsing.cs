using System;
using server.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace server.Configurations
{
    public class Parsing : StartupConfig
    {

        public Parsing(IHostingEnvironment env, IConfiguration config) : base(env, config) { }

        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            return null;
        }

        public override void Configure(IApplicationBuilder app)
        {

            app.UseCors(builder =>
            {
                builder.WithOrigins(new string[] { "*" })
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });

            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

        }

    }
}
    