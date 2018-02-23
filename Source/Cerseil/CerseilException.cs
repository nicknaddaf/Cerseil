using System;
using System.Runtime.Serialization;

namespace Cerseil
{
    [Serializable]
    public class CerseilException : Exception
    {
        private const string ExceptionMessage = "Cerseil Exception: {0}";

        public CerseilException()
        {
        }

        public CerseilException(string message)
            : base(string.Format(ExceptionMessage, message))
        {
        }

        public CerseilException(string message, Exception innerException)
            : base(string.Format(ExceptionMessage, message), innerException)
        {
        }

        protected CerseilException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
