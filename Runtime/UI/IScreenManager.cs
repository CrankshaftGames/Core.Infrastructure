namespace Core.Infrastructure.UI
{
    public interface IScreenManager
    {
        void RegisterScreen<TScreen>(IUserInterfaceFactory<TScreen> screen) where TScreen : IScreen;
        void RegisterPopup<TPopup>(IUserInterfaceFactory<TPopup> popup) where TPopup : IPopup;
        void ShowScreen<TScreen>() where TScreen : IScreen;
        void HideScreen<TScreen>() where TScreen : IScreen;
        void ShowPopup<TPopup>(bool onTop = false) where TPopup : IPopup;
        void HidePopup<TPopup>() where TPopup : IPopup;
        void HideAllPopups();
    }
}