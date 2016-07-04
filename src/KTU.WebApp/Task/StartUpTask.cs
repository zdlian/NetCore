
//using System;
//using System.Collections.Generic;

using Autofac;
using KTU.Core.Base;

namespace KTU.WebApp.Task
{
	public class StartupTask : IRegisterType
	{
		public void Register(ContainerBuilder container)
		{
			container.RegisterType<AuthenticationTask>().As<IAuthenticationTask>();
		}
	}
}
