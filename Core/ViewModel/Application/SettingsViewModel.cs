using System.Windows.Input;
using wpf_advance.Core;

namespace Core
{
    public class SettingsViewModel : BaseViewModel
    {
        public TextEntryViewModel Name { get; set; }
        public TextEntryViewModel UserName { get; set; }
        public TextEntryViewModel Password { get; set; }
        public TextEntryViewModel Email { get; set; }
        public ICommand Open => new RelayCommand(() => IoC.Application.SettingsMenuVisible = true);
        public ICommand Close => new RelayCommand(() => IoC.Application.SettingsMenuVisible = false);
    }
}
