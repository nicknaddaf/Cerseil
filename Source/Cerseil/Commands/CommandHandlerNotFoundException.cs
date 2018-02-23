using System;

namespace Cerseil.Commands
{
    [Serializable]
    public class CommandHandlerNotFoundException : CerseilException
    {
        public CommandHandlerNotFoundException(Type type)
            : base(string.Format("Command handler not found for command type: {0}", type))
        {
        }
    }
}
