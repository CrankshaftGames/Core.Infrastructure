namespace Core.Infrastructure.Behaviors
{
    public interface IUpdateEventReceiver : IEventReceiver
    {
        void Update(float dt);
    }
}