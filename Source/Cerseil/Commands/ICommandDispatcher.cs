using System.Collections.Generic;

namespace Cerseil.Commands
{
    public interface ICommandDispatcher
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;

        ICommandResult<TResult> Submit<TCommand, TResult>(TCommand command) where TCommand : ICommand;

        IList<ICommandValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;

        ICommandHandler<TCommand> GetCommandHandler<TCommand>() where TCommand : ICommand;

        ICommandHandler<TCommand, TResult> GetCommandHandler<TCommand, TResult>() where TCommand : ICommand;
    }
}
