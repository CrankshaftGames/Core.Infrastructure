using Core.Infrastructure.Controllers;

namespace Core.Infrastructure
{
	public abstract class EntryPoint<T> where T : RootController
	{
		private T RootController { get; set; }

		protected EntryPoint(T rootController)
		{
			RootController = rootController;
		}
	}
}