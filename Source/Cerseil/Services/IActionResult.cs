using System.Collections.Generic;

using Cerseil.Commands;

namespace Cerseil.Services
{
    public interface IActionResult
    {
        ICommandResult CommandResult { get; }

        IList<ICommandValidationResult> ValidationResults { get; }

        bool Success { get; }

        string ErrorMessage { get; }
    }

    public interface IActionResult<TCommand> : IActionResult where TCommand : ICommand
    {
        TCommand Command { get; }
    }
}
