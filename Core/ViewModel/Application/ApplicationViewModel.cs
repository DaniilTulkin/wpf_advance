using wpf_advance.Core;

namespace Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;
        public BaseViewModel CurrentPageViewModel { get; set; }
        public bool SideMenuVisible { get; set; } = true;
        public bool SettingsMenuVisible { get; set; }
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            CurrentPageViewModel = viewModel;

            SettingsMenuVisible = false;
            CurrentPage = page;
            OnPropertyChanged(nameof(CurrentPage));

            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
