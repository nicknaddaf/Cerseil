using Cerseil.Data;

namespace Cerseil
{
    public abstract class BootstrapperBase : IBootstrapper
    {
        protected BootstrapperBase(string commandsAssemblyName, string repositoriesAssemblyName)
            : this(commandsAssemblyName, repositoriesAssemblyName, "Repository", "Service")
        {
        }

        protected BootstrapperBase(string commandsAssemblyName, string repositoriesAssemblyName,
            string repositorySuffix, string serviceSuffix)
        {
            CommandsAssemblyName = commandsAssemblyName;
            RepositoriesAssemblyName = repositoriesAssemblyName;
            RepositorySuffix = repositorySuffix;
            ServiceSuffix = serviceSuffix;
        }

        public string CommandsAssemblyName { get; protected set; }

        public string RepositoriesAssemblyName { get; protected set; }

        public string RepositorySuffix { get; protected set; }

        public string ServiceSuffix { get; protected set; }

        public IDataContext DataContextObject { get; protected set; }

        public void SetDataContextObject<TDataContext>(TDataContext dataContext) where TDataContext : IDataContext
        {
            DataContextObject = dataContext;
        }

        public TDataContext GetDataContextObject<TDataContext>() where TDataContext : IDataContext
        {
            return (TDataContext)DataContextObject;
        }

        public virtual void Run()
        {
            Initialize();
        }

        public abstract void Initialize();
    }
}
