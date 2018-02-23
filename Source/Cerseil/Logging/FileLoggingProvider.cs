using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerseil.Logging
{
    public class FileLoggingProvider : ILoggingProvider
    {
        public FileLoggingProvider()
        {
        }

        public void Log(object message, LoggingLevel level, Exception exception, string source)
        {
            var logPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\CerseilLogs\";

            if(Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            var fileName = logPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-fff") + ".txt";

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("================================================================================");
            stringBuilder.AppendLine("Cerseil Logging Engine - File Logging Provider");
            stringBuilder.AppendLine("================================================================================");
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("");

            stringBuilder.AppendLine("Logging Date:");
            stringBuilder.AppendLine("====================");
            stringBuilder.AppendLine(DateTime.Now.ToString("dddd - yyyy-MM-dd @ HH:mm:ss:fff"));
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("");

            if (message != null)
            {
                stringBuilder.AppendLine("Message:");
                stringBuilder.AppendLine("====================");
                stringBuilder.AppendLine(message.ToString());
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("");
            }

            stringBuilder.AppendLine("Logging Level:");
            stringBuilder.AppendLine("====================");
            stringBuilder.AppendLine(level.ToString());
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("");

            if (!string.IsNullOrEmpty(source))
            {
                stringBuilder.AppendLine("Logging Source:");
                stringBuilder.AppendLine("====================");
                stringBuilder.AppendLine(source);
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("");
            }

            if (exception != null)
            {
                stringBuilder.AppendLine("Exception Info:");
                stringBuilder.AppendLine("====================");

                stringBuilder.AppendLine(exception.ToString());
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("");

                if(exception.InnerException != null)
                {
                    stringBuilder.AppendLine(exception.InnerException.ToString());
                    stringBuilder.AppendLine("");
                    stringBuilder.AppendLine("");

                    if (exception.InnerException.InnerException != null)
                    {
                        stringBuilder.AppendLine(exception.InnerException.InnerException.ToString());
                        stringBuilder.AppendLine("");
                        stringBuilder.AppendLine("");

                        if (exception.InnerException.InnerException.InnerException != null)
                        {
                            stringBuilder.AppendLine(exception.InnerException.InnerException.InnerException.ToString());
                            stringBuilder.AppendLine("");
                            stringBuilder.AppendLine("");
                        }
                    }
                }
            }

            stringBuilder.AppendLine("");

            File.AppendAllText(fileName, stringBuilder.ToString());
            stringBuilder.Clear();
        }
    }
}
