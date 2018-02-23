using System.Collections.Generic;

using Cerseil.Commands;

namespace Cerseil.Services
{
    public interface IServiceResult
    {
        IEnumerable<ICommandValidationResult> ValidationResults { get; }

        IEnumerable<ICommandResult> CommandResults { get; }

        string ReturnMessage { get; }

        ActionResultList ActionResults { get; }

        bool Success { get; }

        void SetReturnMessage(string returnMessage);

        void AddValidationResult(ICommandValidationResult validationResult);

        void AddValidationResults(IEnumerable<ICommandValidationResult> validationResults);

        void AddCommandResult(ICommandResult commandResult);

        void AddCommandResults(IEnumerable<ICommandResult> commandResults);

        IEnumerable<string> GetErrorMessages();

        string GetFirstErrorMessage();
    }

    public interface IServiceResult<TReturnResult> : IServiceResult
    {
        TReturnResult ReturnResult { get; }

        void SetReturnResult(TReturnResult returnResult);
    }
}
