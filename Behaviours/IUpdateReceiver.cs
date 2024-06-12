namespace Core.Infrastructure.Behaviours
{
	public interface IUpdateReceiver : IEventReceiver
	{
		void Update(float dt);
	}
}
