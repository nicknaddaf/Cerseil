using System;

namespace Cerseil.Logging
{
    public interface ILoggingProvider
    {
        void Log(object message, LoggingLevel level, Exception exception, string source);
    }
}
