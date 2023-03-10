using Ninject;
using wpf_advance.Core;

namespace Core
{
    public static class IoC
    {
        public static IKernel Kernel { get; private set; } = new StandardKernel();
        public static IUIMenager UI => Get<IUIMenager>();
        public static ApplicationViewModel Application => Get<ApplicationViewModel>();
        public static SettingsViewModel Settings => Get<SettingsViewModel>();
        public static ILogFactory Logger => Get<ILogFactory>();
        public static IFileManager File => Get<IFileManager>();
        public static ITaskManager Task => Get<ITaskManager>();

        public static T Get<T>() => Kernel.Get<T>();

        public static void Setup()
        {
            BindViewModels();
        }

        private static void BindViewModels()
        {
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }
    }
}
