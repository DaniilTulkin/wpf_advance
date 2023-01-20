using Core;
using System.Windows;
using wpf_advance.Core;

namespace wpf_advance
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();
            IoC.Logger.Log("Application starting up...");
            IoC.Task.Run(() =>
            {
            });

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            {
                new FileLogger("log.txt"),
            }));
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());
            IoC.Kernel.Bind<IUIMenager>().ToConstant(new UIManager());
        }
    }
}
