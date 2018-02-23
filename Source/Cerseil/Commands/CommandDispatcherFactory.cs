namespace Cerseil.Commands
{
    public class CommandDispatcherFactory
    {
        private readonly ICommandDispatcher _commandDispatcher = null;

        public CommandDispatcherFactory()
        {
            var commandDispatcher = DependencyManager.Current.Resolver.GetService<ICommandDispatcher>();

            if (commandDispatcher == null)
            {
                _commandDispatcher = new DefaultCommandDispatcher();
            }
        }

        public ICommandDispatcher GetCommandDispatcher()
        {
            return _commandDispatcher;
        }
    }
}
