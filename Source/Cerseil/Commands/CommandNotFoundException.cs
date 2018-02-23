using System;

namespace Cerseil.Commands
{
    [Serializable]
    public class CommandNotFoundException : CerseilException
    {
        public CommandNotFoundException(Type type)
            : base(string.Format("Command of type: {0} has not been found!", type))
        {
        }
    }
}
