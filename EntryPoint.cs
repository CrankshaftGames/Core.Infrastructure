using Core.Infrastructure.Controllers;

namespace Core.Infrastructure
{
    public abstract class EntryPoint<T> where T : RootController
    {
        protected EntryPoint(T rootController)
        {
            RootController = rootController;
        }

        private T RootController { get; set; }
    }
}