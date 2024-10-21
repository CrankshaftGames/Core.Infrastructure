using System.Threading.Tasks;

namespace Core.Infrastructure.Assets
{
    public interface IAssetsService
    {
        Task<T> Load<T>(string key);
    }
}