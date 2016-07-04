using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KTU.Core.FluginManager
{
  public interface IModuleBase
  {
    void SetConfigurationRoot(IConfigurationRoot configurationRoot);
    void ConfigureServices(IServiceCollection services);
    void Configure(IApplicationBuilder applicationBuilder);
  }
}