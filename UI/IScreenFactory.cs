namespace Core.Infrastructure.UI
{
    public interface IScreenFactory<out TScreen> where TScreen : IScreen
    {
        TScreen Create();
    }
}