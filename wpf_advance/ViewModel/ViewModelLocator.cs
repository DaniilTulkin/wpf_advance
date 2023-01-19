using Core;

namespace wpf_advance
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => IoC.Application;
        public static SettingsViewModel SettingsViewModel => IoC.Settings;
    }
}
