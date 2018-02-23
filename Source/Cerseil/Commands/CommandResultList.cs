using System.Collections.Generic;
using System.Linq;

namespace Cerseil.Commands
{
    public class CommandResultList : ICommandResultList
    {
        public CommandResultList()
        {
            Results = new List<ICommandResult>();
        }

        public void AddResult(ICommandResult result)
        {
            Results.Add(result);
        }

        public bool Success
        {
            get { return Results.All<ICommandResult>(result => result.Success); }
        }

        public IList<ICommandResult> Results
        {
            get;
            private set;
        }
    }
}
