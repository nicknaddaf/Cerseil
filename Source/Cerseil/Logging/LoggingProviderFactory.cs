namespace Cerseil.Logging
{
    public class LoggingProviderFactory : ILoggingProviderFactory
    {
        private readonly ILoggingProvider _loggingProvider;

        public LoggingProviderFactory()
        {
            _loggingProvider = DependencyManager.Current.Resolver.GetService<ILoggingProvider>();
        }

        public ILoggingProvider GetLoggingProvider()
        {
            return _loggingProvider;
        }
    }
}
