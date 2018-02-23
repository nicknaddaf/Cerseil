using System;
using System.Linq;
using System.Transactions;

using Cerseil.Commands;

namespace Cerseil.Services
{
    public sealed class ActionContext : IActionContext
    {
        public ActionContext()
        {
            Actions = new ScheduledActionList();
            ActionResults = new ActionResultList();
        }

        public bool IsInTransaction { get; private set; }

        public bool IsDirty { get; private set; }

        public ScheduledActionList Actions { get; private set; }

        public ActionResultList ActionResults { get; private set; }

        public void ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new CerseilException("The command object cannot be null. You cannot process the command if it is null!");
            }

            var scheduledAction = new ScheduledAction<TCommand>(command);
            ManageAction<TCommand>(scheduledAction);
        }

        public void ProcessCommand<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new CerseilException("The command object cannot be null. You cannot process the command if it is null!");
            }

            var scheduledAction = new ScheduledAction<TCommand, TResult>(command);
            ManageAction<TCommand, TResult>(scheduledAction);
        }

        public void BeginTransaction()
        {
            if (IsInTransaction)
            {
                throw new CerseilException("A transaction is already opened");
            }

            IsInTransaction = true;
        }

        public void Commit()
        {
            if (!IsInTransaction)
            {
                throw new CerseilException("This operation requires an opened transaction");
            }

            using (var transaction = new TransactionScope())
            {
                if (Actions != null)
                {
                    foreach (var scheduledAction in Actions.Actions)
                    {
                        scheduledAction.Execute();
                        ActionResults.AddActionResult(scheduledAction.Result);

                        if (!scheduledAction.Result.Success)
                        {
                            break;
                        }
                    }

                    // This should be called only if all ScheduledActions have no errors;
                    if (!ActionResults.ValidationResults.Any())
                    {
                        transaction.Complete();
                    }
                }
            }
        }

        public void Rollback()
        {
            if (!IsInTransaction)
            {
                throw new CerseilException("This operation requires an opened transaction");
            }

            IsInTransaction = false;

            Clear();
        }

        public void Clear()
        {
            Actions.Actions.Clear();

            ActionResults.ActionResults.Clear();

            ActionResults.ValidationResults.Clear();

            IsDirty = false;
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (IsInTransaction)
                    {
                        Rollback();
                    }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ActionContext() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);

            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion

        private void ManageAction<TCommand>(ScheduledAction<TCommand> scheduledAction) where TCommand : ICommand
        {
            if (IsInTransaction)
            {
                // Add action to the list
                Actions.AddAction<TCommand>(scheduledAction);
                IsDirty = true;
            }
            else
            {
                // Execute the single action
                scheduledAction.Execute();
                ActionResults.AddActionResult(scheduledAction.Result);
            }
        }

        private void ManageAction<TCommand, TResult>(ScheduledAction<TCommand, TResult> scheduledAction) where TCommand : ICommand
        {
            if (IsInTransaction)
            {
                // Add action to the list
                Actions.AddAction<TCommand, TResult>(scheduledAction);
                IsDirty = true;
            }
            else
            {
                // Execute the single action
                scheduledAction.Execute();
                ActionResults.AddActionResult(scheduledAction.Result);
            }
        }
    }
}
