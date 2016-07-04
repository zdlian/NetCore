using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using KTU.Core.Base;
using System.Linq;
using KTU.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using KTU.DataAccess.Seed;
using KTU.Core.FluginManager;
using KTU.WebApp.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.FileProviders;
using CompositeFileProvider = Microsoft.Extensions.FileProviders.CompositeFileProvider;
using Microsoft.AspNetCore.Mvc.Razor;

namespace KTU.WebApp
{
	public class Startup
	{
		private readonly ContainerBuilder _containerBuilder = new ContainerBuilder();

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();

			if (env.IsDevelopment())
			{
				// This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
				builder.AddApplicationInsightsSettings(developerMode: true);
			}
			Configuration = builder.Build();

			// Init assemply
			InitializeAssemblies();
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			services.AddApplicationInsightsTelemetry(Configuration);
			
			// Build the Mvc builder, this includes authorization and view engine location
			var mvcBuilder = new MvcBuilder(this);
			mvcBuilder.ConfigurateMvcBuilder(services);

			services.AddSession();
			services.AddAuthentication();

			// use the Entity Framework 1.0 core
			services.AddDbContext<SimpleDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
				b => b.MigrationsAssembly("KTU.WebApp")));

			// register autofac
			_containerBuilder.RegisterInstance(Configuration);

			// Register for autofact
			// [TODO] use the extendtion to refactor this code 
			AutofacBuilder.Register(_containerBuilder,this);
		   _containerBuilder.Populate(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseApplicationInsightsRequestTelemetry();

			// We use form authentication
			// Check the web configuration to find out the form authentication
			app.UseCookieAuthentication(new CookieAuthenticationOptions()
			{
				CookieName = ".AppCookie",
				AutomaticAuthenticate = true,
				AutomaticChallenge = true,
				LoginPath = new PathString("/login/login"),
				AuthenticationScheme = ".AppCookie",
			});

			// Use the HttpContext.Session
			app.UseSession();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();

				// Insert Seed Data in EF core
				using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
				.CreateScope())
				{
					serviceScope.ServiceProvider.GetService<SimpleDbContext>().Database.Migrate();
					serviceScope.ServiceProvider.GetService<SimpleDbContext>().EnsureSeedData();
				}
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseApplicationInsightsExceptionTelemetry();
			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=login}/{action=login}/{id?}");
			});

			ConfigurateApplicationService(app);
		}

		private void ConfigurateApplicationService(IApplicationBuilder app)
		{
			// Configuration for all module
			foreach (IModuleBase extension in AssemplyManager.Modules)
			{
				extension.Configure(app);
			}

			var container = _containerBuilder.Build();
			app.ApplicationServices = container.Resolve<IServiceProvider>();
		}

		private void InitializeAssemblies()
		{
			//[TODO tiepkn] shoud be load from path file rather than hard code
			var modules = new List<string>() { "KTU.Asset.Management.Web" };
			AssemplyManager.SetAssemblies(modules.Select(module => Assembly.Load(new AssemblyName(module))));
		}
	}
}
