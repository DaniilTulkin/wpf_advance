using System;
using System.Windows.Input;
using wpf_advance.Core;

namespace Core
{
    public class SettingsViewModel : BaseViewModel
    {
        public TextEntryViewModel Name { get; set; }
        public TextEntryViewModel UserName { get; set; }
        public PasswordEntryViewModel Password { get; set; }
        public TextEntryViewModel Email { get; set; }
        public string LogoutButtonsText { get; set; } = "Logout";

        private void ClearUserData()
        {
            Name = null;
            UserName = null; 
            Password = null; 
            Email = null;
        }
        public ICommand Open => new RelayCommand(() => IoC.Application.SettingsMenuVisible = true);
        public ICommand Close => new RelayCommand(() => IoC.Application.SettingsMenuVisible = false);
        public ICommand Logout => new RelayCommand(() =>
        {
            ClearUserData();
            IoC.Application.GoToPage(ApplicationPage.Login);
        });
    }
}
