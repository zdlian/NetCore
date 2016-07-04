﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KTU.Core.FluginManager;

namespace KTU.Asset.Web
{
  public class DataExtension : IExtension
  {
    private IConfigurationRoot configurationRoot;

    public string Name
    {
      get
      {
        return "Data Extension";
      }
    }

    public IDictionary<int, Action<IRouteBuilder>> RouteRegistrarsByPriorities
    {
      get
      {
        return null;
      }
    }

    public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
    {
      this.configurationRoot = configurationRoot;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      //Type type = ExtensionManager.GetImplementation<IStorage>(a => a.FullName.ToLower().Contains("data"));

      //if (type != null)
      //{
      //  PropertyInfo connectionStringPropertyInfo = type.GetProperty("ConnectionString");

      //  if (connectionStringPropertyInfo != null)
      //    connectionStringPropertyInfo.SetValue(null, this.configurationRoot["Data:DefaultConnection:ConnectionString"]);

      //  services.AddScoped(typeof(IStorage), type);
      //}
    }

    public void Configure(IApplicationBuilder applicationBuilder)
    {

    }
  }
}