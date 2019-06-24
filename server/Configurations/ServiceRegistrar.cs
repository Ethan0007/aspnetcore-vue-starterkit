using System;
using server.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace server.Configurations
{
    public class ServiceRegistrar : StartupConfig
    {
        public ServiceRegistrar(IHostingEnvironment env, IConfiguration config) : base(env, config) { }

        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {

            // Hosting environment
            services.AddSingleton<IHostingEnvironment>(Env);
            // Register all configuration to services
            services.AddSingleton<IConfiguration>(Config);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return null;
        }
    }
}