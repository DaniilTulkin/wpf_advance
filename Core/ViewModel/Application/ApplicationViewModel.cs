using wpf_advance.Core;

namespace Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;
        public bool SideMenuVisible { get; set; } = false;
        public bool SettingsMenuVisible { get; set; }
        public void GoToPage(ApplicationPage page)
        {
            SettingsMenuVisible = false;
            CurrentPage = page;
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
