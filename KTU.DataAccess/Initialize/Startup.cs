using Autofac;
using KTU.Core.Base;
using KTU.DataAccess.Repository;

namespace KTU.DataAccess.Initialize
{
	public class Startup : IRegisterType
    {
	    public void Register(ContainerBuilder container)
	    {
			container.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

		}
    }
}
