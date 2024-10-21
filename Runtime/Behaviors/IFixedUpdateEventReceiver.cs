namespace Core.Infrastructure.Behaviors
{
    public interface IFixedUpdateEventReceiver : IEventReceiver
    {
        void FixedUpdate(float fixedDt);
    }
}