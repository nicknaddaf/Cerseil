using System.Collections.Generic;

namespace Cerseil.Commands
{
    public interface ICommandValidator<in TCommand> where TCommand : ICommand
    {
        IList<ICommandValidationResult> Validate(TCommand command);
    }
}
