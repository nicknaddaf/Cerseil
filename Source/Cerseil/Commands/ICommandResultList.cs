using System.Collections.Generic;

namespace Cerseil.Commands
{
    public interface ICommandResultList
    {
        IList<ICommandResult> Results { get; }

        bool Success { get; }

        void AddResult(ICommandResult result);
    }
}
