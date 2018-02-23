using System;

namespace Cerseil.Services
{
    public class ActionContextFactory
    {
        public static IActionContext GetActionContext()
        {
            var actionContext = DependencyManager.Current.Resolver.GetService<IActionContext>() ?? new ActionContext();

            return actionContext;
        }
    }
}
