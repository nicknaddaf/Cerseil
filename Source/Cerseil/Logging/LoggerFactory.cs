namespace Cerseil.Logging
{
    public static class LoggerFactory
    {
        public static ILogger GetLoggerInstance()
        {
            var loggingProviderFactory = DependencyManager.Current.Resolver.GetService<ILoggingProviderFactory>();

            if (loggingProviderFactory == null)
            {
                throw new CerseilException("The ILoggingProviderFactory instance in null.");
            }

            var loggerConfigurationFactory = DependencyManager.Current.Resolver.GetService<ILoggerConfigurationFactory>() ??
                                             new LoggerConfigurationFactory();

            var logger = new Logger(loggingProviderFactory, loggerConfigurationFactory);

            return logger;
        }
    }
}
