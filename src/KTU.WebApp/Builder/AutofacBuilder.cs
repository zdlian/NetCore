using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using KTU.Core.Base;

namespace KTU.WebApp.Builder
{
	public class AutofacBuilder
	{
		public static void Register(ContainerBuilder containerBuilder, Startup startup)
		{
			containerBuilder.RegisterInstance(startup.Configuration);
			RegisterAssemply(containerBuilder);
		}

		private static void RegisterAssemply(ContainerBuilder containerBuilder)
		{
			//[TODO tiepkn] shoud be load from path file rather than hard code
			var modules = new List<string>() {"KTU.WebApp", "KTU.DataAccess", "KTU.Services"};
			foreach (var assembly in modules.Select(module => Assembly.Load(new AssemblyName(module))))
			{
				var types = assembly.GetTypes().Where(s => s.IsAssignableTo<IRegisterType>());
				foreach (var type in types)
				{
					var registerType = Activator.CreateInstance(type) as IRegisterType;
					if (registerType != null)
					{
						registerType.Register(containerBuilder);
					}
				}
			}
		}
	}
}