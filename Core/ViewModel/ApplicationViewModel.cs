using wpf_advance.Core;

namespace Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;
        public bool SideMenuVisible { get; set; } = false;
        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
