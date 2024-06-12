using System.Threading.Tasks;

namespace Core.Infrastructure.Features
{
	public interface IFeature
	{
		Task<bool> Initialize();
		void Run();
		void Terminate();
	}
}