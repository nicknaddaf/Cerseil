namespace Cerseil.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }

        string Message { get; }
    }

    public interface ICommandResult<TResult> : ICommandResult
    {
        TResult Result { get; }

        void SetResult(TResult result);
    }
}
