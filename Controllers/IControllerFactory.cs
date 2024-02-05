namespace Core.Infrastructure.Controllers
{
    public interface IControllerFactory
    {
        T Create<T>() where T : Controller;
    }
}