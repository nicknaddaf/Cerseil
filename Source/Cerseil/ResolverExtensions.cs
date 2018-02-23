using System.Collections.Generic;
using System.Linq;

namespace Cerseil
{
    public static class ResolverExtensions
    {
        public static TService GetService<TService>(this IResolver resolver)
        {
            if (resolver == null)
            {
                throw new CerseilException("The IResolver parameter cannot be null!");
            }

            return (TService)resolver.GetService(typeof(TService));
        }

        public static IEnumerable<TService> GetServices<TService>(this IResolver resolver)
        {
            if (resolver == null)
            {
                throw new CerseilException("The IResolver parameter cannot be null!");
            }

            return resolver.GetServices(typeof(TService)).Cast<TService>();
        }
    }
}
