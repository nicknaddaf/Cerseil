using Cerseil.Data;
using Cerseil.Caching;
using Cerseil.Logging;

namespace Cerseil.Services
{
    public interface IService
    {
        ICacheManagerFactory CacheManagerFactory { get; }

        ICacheManager CacheManager { get; }

        IActionContext ActionContext { get; }

        ILogger Logger { get; }

        TRepository GetRepository<TRepository>() where TRepository : IRepository;
    }
}
