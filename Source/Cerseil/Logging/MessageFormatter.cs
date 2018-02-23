using System;

namespace Cerseil.Logging
{
    public class MessageFormatter
    {
        private volatile string _cachedMessage;
        
        public MessageFormatter(IFormatProvider formatProvider, string message, params object[] args)
        {
            FormatProvider = formatProvider;
            Message = message;
            Args = args;
        }

        public IFormatProvider FormatProvider { get; private set; }

        public string Message { get; private set; }

        public object[] Args { get; private set; }

        public override string ToString()
        {
            if (_cachedMessage == null && Message != null)
            {
                _cachedMessage = string.Format(FormatProvider, Message, Args);
            }
            
            return _cachedMessage;
        }
    }
}
