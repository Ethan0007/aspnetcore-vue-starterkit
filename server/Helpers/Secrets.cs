/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace server.Helpers {
  public class Secrets : IConfiguration {

    public string this[string key] {
      get => throw new System.NotImplementedException();
      set => throw new System.NotImplementedException();
    }

    private IConfigurationRoot Configuration;

    public Secrets(IServiceProvider sp, IConfiguration configBase) {
      var builder = new ConfigurationBuilder();
      var file = "appsettings.json";
      builder.AddJsonFile(file, optional: true, reloadOnChange: true);
      Configuration = builder.Build();
    }

    public IEnumerable<IConfigurationSection> GetChildren() {
      return Configuration.GetChildren();
    }

    public IChangeToken GetReloadToken() {
      return Configuration.GetReloadToken();
    }

    public IConfigurationSection GetSection(string key) {
      return Configuration.GetSection(key);
    }

  }
}