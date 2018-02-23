namespace Cerseil.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        ICommandResult Execute(TCommand command);
    }

    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
    {
        ICommandResult<TResult> Execute(TCommand command);
    }
}
