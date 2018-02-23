using System.Collections.Generic;

using Cerseil.Commands;

namespace Cerseil.Services
{
    public class ScheduledActionList
    {
        public ScheduledActionList()
        {
            Actions = new List<IScheduledAction>();
        }

        public void AddAction<TCommand>(ScheduledAction<TCommand> action) where TCommand : ICommand
        {
            Actions.Add(action);
        }

        public void AddAction<TCommand, TResult>(ScheduledAction<TCommand, TResult> action) where TCommand : ICommand
        {
            Actions.Add(action);
        }

        public IList<IScheduledAction> Actions { get; private set; }
    }
}
