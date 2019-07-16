/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace server.Helpers {
  public class StartupConfig : IStartup {

    protected readonly IHostingEnvironment Env;
    protected readonly IConfiguration Config;

    public StartupConfig(IHostingEnvironment env, IConfiguration config) {
      Env = env;
      Config = config;
    }

    public virtual void Configure(
      IApplicationBuilder app) { }

    public virtual IServiceProvider ConfigureServices(
      IServiceCollection services) {
      return null;
    }

  }

}