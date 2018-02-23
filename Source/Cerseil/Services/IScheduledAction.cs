using Cerseil.Commands;

namespace Cerseil.Services
{
    public interface IScheduledAction
    {
        ICommandDispatcher CommandDispatcher { get; }

        IActionResult Result { get; }

        void Execute();
    }
}
