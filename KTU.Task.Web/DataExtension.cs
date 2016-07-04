// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KTU.Core.FluginManager;

namespace KTU.Task.Web
{
	public class DataExtension : IExtension
	{
		private IConfigurationRoot configurationRoot;

		public string Name => "Data Extension";

		public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
		{
			this.configurationRoot = configurationRoot;
		}

		public void ConfigureServices(IServiceCollection services)
		{

		}

		public void Configure(IApplicationBuilder applicationBuilder)
		{
		}

		public void RegisterRoutes(IRouteBuilder routeBuilder)
		{
			routeBuilder.MapRoute(
					name: "default",
					template: "{controller=task}/{action=index}/{id?}");
		}
	}
}