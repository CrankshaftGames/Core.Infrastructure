namespace Core.Infrastructure.Controllers
{
	public interface IControllerFactory
	{
		T Create<T>() where T : Controller;
	}

	public interface IControllerFactory<out TController> where TController : Controller
	{
		TController Create();
	}
}