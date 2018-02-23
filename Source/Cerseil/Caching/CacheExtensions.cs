using System;

namespace Cerseil.Caching
{
    public static class CacheExtensions
    {
        // This is where the time for caching is set
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 3600, acquire);
        }

        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();

                cacheManager.Set<T>(key, result, cacheTime);

                return result;
            }
        }
    }
}
