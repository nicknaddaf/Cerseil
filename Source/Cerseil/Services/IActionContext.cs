using System;

using Cerseil.Commands;

namespace Cerseil.Services
{
    public interface IActionContext : IDisposable
    {
        bool IsInTransaction { get; }

        bool IsDirty { get; }

        ScheduledActionList Actions { get; }

        ActionResultList ActionResults { get; }

        void ProcessCommand<TCommand>(TCommand command) where TCommand : ICommand;

        void ProcessCommand<TCommand, TResult>(TCommand command) where TCommand : ICommand;

        void BeginTransaction();

        void Commit();

        void Rollback();

        void Clear();
    }
}
