using Cerseil.Caching;
using Cerseil.Data;
using Cerseil.Logging;

namespace Cerseil.Services
{
    public abstract class ServiceBase : IService
    {
        protected ServiceBase()
        {
            CacheManagerFactory = DependencyManager.Current.Resolver.GetService<ICacheManagerFactory>();

            CacheManager = CacheManagerFactory.GetCacheManager();

            ActionContext = ActionContextFactory.GetActionContext();

            Logger = LoggerFactory.GetLoggerInstance();
        }

        public ICacheManagerFactory CacheManagerFactory { get; private set; }

        public ICacheManager CacheManager { get; private set; }

        public IActionContext ActionContext { get; private set; }

        public ILogger Logger { get; private set; }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            return RepositoryResolver.GetRepository<TRepository>();
        }
    }
}
