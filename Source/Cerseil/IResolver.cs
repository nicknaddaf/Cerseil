using System;
using System.Collections.Generic;

namespace Cerseil
{
    public interface IResolver
    {
        object GetService(Type serviceType);

        IEnumerable<object> GetServices(Type serviceType);
    }
}
