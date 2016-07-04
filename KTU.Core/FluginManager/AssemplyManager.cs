using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;

namespace KTU.Core.FluginManager
{
	public static class AssemplyManager
	{
		private static IEnumerable<Assembly> _assemblies;
		private static IEnumerable<IModuleBase> _modules;

		public static IEnumerable<Assembly> Assemblies => AssemplyManager._assemblies;

		public static void SetAssemblies(IEnumerable<Assembly> assemblies)
		{
			_assemblies = assemblies;
		}
		public static IEnumerable<IModuleBase> Modules
		{
			get
			{
				if (AssemplyManager.Assemblies == null)
					throw new InvalidOperationException("Assemblies not set");
				if (AssemplyManager._modules == null)
				{
					List<IModuleBase> list = (from assembly in AssemplyManager.Assemblies from type in assembly.GetTypes().Where(s => s.IsAssignableTo<IModuleBase>())
											  let registerType = Activator.CreateInstance(type) as IModuleBase where registerType != null
											  select (IModuleBase) Activator.CreateInstance(type)).ToList();
					_modules = list;
				}
				return AssemplyManager._modules;
			}
			
		}
	}
}