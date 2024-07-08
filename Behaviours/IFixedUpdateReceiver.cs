namespace Core.Infrastructure.Behaviours
{
    public interface IFixedUpdateReceiver : IEventReceiver
    {
        void FixedUpdate(float fixedDt);
    }
}