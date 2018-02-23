namespace Cerseil.Data
{
    public class DataContextFactory
    {
        public static IDataContext GetDataContextInstance(string nameOrConnectionString)
        {
            var dataContext = DependencyManager.Current.Resolver.GetService<IDataContext>();

            return dataContext;
        }
    }
}
