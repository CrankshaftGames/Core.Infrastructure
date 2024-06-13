using System.Threading.Tasks;

namespace Core.Infrastructure.Features
{
	public interface IFeature
	{
		Task Run();
		void Terminate();
	}
}