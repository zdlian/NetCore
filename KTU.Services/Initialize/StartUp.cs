using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using KTU.Core.Base;
using KTU.DataAccess.Repository;
using KTU.Services.Services.UserService;

namespace KTU.Services.Initialize
{
    public class StartUp : IRegisterType
    {
	    public void Register(ContainerBuilder container)
	    {
		    container.RegisterType<UserService>().As<IUserService>();
	    }
    }
}
