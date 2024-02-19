using Core.Implementation.UI;

namespace Core.Infrastructure.UI
{
    public interface IUserInterface
    {
        RoutineToken Show();
        RoutineToken Hide();
    }
}