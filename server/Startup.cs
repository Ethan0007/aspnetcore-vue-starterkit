using server.Helpers;
using server.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private List<StartupConfig> Startups;
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            this.BuildServiceConfigurations(env);
        }

        private void BuildServiceConfigurations(IHostingEnvironment env)
        {
            Startups = new List<StartupConfig>();
            Startups.Add(new ServiceRegistrar(env, Configuration));
            Startups.Add(new Parsing(env, Configuration));
            Startups.Add(new Authentication(env, Configuration));
            Startups.Add(new ApiRouting(env, Configuration));
            Startups.Add(new SpaRouting(env, Configuration));
    
            // #ADD more service startup config
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            foreach (var startup in Startups) startup.ConfigureServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            foreach (var startup in Startups) startup.Configure(app);
            // Done configuring, clean up collection.

            Startups.Clear();
        }
    }
}
