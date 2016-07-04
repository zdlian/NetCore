using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KTU.Core.FluginManager;

namespace KTU.Asset.Management.Web
{
  public class DataModuleBase : IModuleBase
  {
    private IConfigurationRoot _configurationRoot;

    public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
    {
      this._configurationRoot = configurationRoot;
    }

    public void ConfigureServices(IServiceCollection services)
    {
			
	}

    public void Configure(IApplicationBuilder applicationBuilder)
    {

    }
  }
}