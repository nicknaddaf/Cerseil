using System;

namespace Cerseil.Commands
{
    [Serializable]
    public class ValidationHandlerNotFoundException : CerseilException
    {
        public ValidationHandlerNotFoundException(Type type)
            : base(string.Format("Validation handler not found for command type: {0}", type))
        {
        }
    }
}
