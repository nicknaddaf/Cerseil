using Cerseil.Data;

namespace Cerseil
{
    public static class RepositoryResolver
    {
        public static TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            return DependencyManager.Current.Resolver.GetService<TRepository>();
        }
    }
}
