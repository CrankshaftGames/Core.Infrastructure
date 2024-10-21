using System.Threading.Tasks;

namespace Core.Infrastructure.UI
{
    public interface IUserInterfaceFactory<T> where T : IUserInterface
    {
        Task<T> Create();
    }
}