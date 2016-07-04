using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace KTU.Core.Base
{
    public interface IRegisterType
    {
	    void Register(ContainerBuilder container);
    }
}
