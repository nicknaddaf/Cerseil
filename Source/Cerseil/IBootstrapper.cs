using Cerseil.Data;

namespace Cerseil
{
    public interface IBootstrapper
    {
        string CommandsAssemblyName { get; }

        string RepositoriesAssemblyName { get; }

        string RepositorySuffix { get; }

        string ServiceSuffix { get; }

        IDataContext DataContextObject { get; }

        void SetDataContextObject<TDataContext>(TDataContext dataContext) where TDataContext : IDataContext;

        TDataContext GetDataContextObject<TDataContext>() where TDataContext : IDataContext;

        void Run();

        void Initialize();
    }
}
