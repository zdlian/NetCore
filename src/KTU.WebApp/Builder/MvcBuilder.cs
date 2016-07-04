using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using KTU.Core.FluginManager;

namespace KTU.WebApp.Builder
{
	public class MvcBuilder
	{
		private readonly Startup _startup;

		public MvcBuilder(Startup startup)
		{
			_startup = startup;
		}

		public void ConfigurateMvcBuilder(IServiceCollection services)
		{
			BuildAuthorization(services);
			ConfigurateViewEngineOptions(services);
			ConfigurateModules(services);
		}

		private static void BuildAuthorization(IServiceCollection services)
		{
			var defaultPolicy =
				new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();

			var mvcBuilder = services.AddMvc(setup => { setup.Filters.Add(new AuthorizeFilter(defaultPolicy)); });
		}

		private static void ConfigurateViewEngineOptions(IServiceCollection services)
		{
			services.Configure<RazorViewEngineOptions>(options =>
			{
				foreach (Assembly assembly in AssemplyManager.Assemblies)
				{
					options.FileProviders.Add(new EmbeddedFileProvider(assembly, assembly.GetName().Name));
				}
			});
		}

		private void ConfigurateModules(IServiceCollection services)
		{
			foreach (IModuleBase module in AssemplyManager.Modules)
			{
				module.SetConfigurationRoot(_startup.Configuration);
				module.ConfigureServices(services);
			}
		}
	}
}