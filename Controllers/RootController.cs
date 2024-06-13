namespace Core.Infrastructure.Controllers
{
	public abstract class RootController : Controller
	{
		public void RunTree()
		{
			Run();
		}

		public void TerminateTree()
		{
			Terminate();
		}
	}
}