using System.Windows.Input;
using wpf_advance.Core;

namespace Core
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand Open => new RelayCommand(() => IoC.Application.SettingsMenuVisible = true);
        public ICommand Close => new RelayCommand(() => IoC.Application.SettingsMenuVisible = false);
    }
}
