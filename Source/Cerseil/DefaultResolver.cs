using System;
using System.Collections.Generic;
using System.Linq;

namespace Cerseil
{
    internal class DefaultResolver : IResolver
    {
        public object GetService(Type serviceType)
        {
            if (serviceType.IsInterface || serviceType.IsAbstract)
            {
                return null;
            }

            return Activator.CreateInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }
}
