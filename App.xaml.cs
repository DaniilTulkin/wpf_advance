﻿using Core;
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

            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            IoC.Setup();
            IoC.Kernel.Bind<IUIMenager>().ToConstant(new UIManager());
        }
    }
}
