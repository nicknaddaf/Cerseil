namespace Cerseil.Caching
{
    public class CacheManagerFactory : ICacheManagerFactory
    {
        private readonly ICacheManager _cacheManager;

        public CacheManagerFactory()
        {
            _cacheManager = DependencyManager.Current.Resolver.GetService<ICacheManager>() ?? new MemoryCacheManager();
        }

        public ICacheManager GetCacheManager()
        {
            return _cacheManager;
        }
    }
}
