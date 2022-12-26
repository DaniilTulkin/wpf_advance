using Core;
using System.Windows;

namespace wpf_advance
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IoC.Setup();
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}
