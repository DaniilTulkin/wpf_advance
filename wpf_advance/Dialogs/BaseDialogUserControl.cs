using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using wpf_advance.Core;

namespace wpf_advance
{
    public class BaseDialogUserControl : UserControl
    {
        private DialogWindow dialogWindow = new DialogWindow();
        public int WindowMinimumWidth { get; set; } = 250;
        public int WindowMinimumHeight { get; set; } = 100;
        public int TitleHeight { get; set; } = 30;
        public string Title { get; set; }

        public BaseDialogUserControl()
        {
            dialogWindow.ViewModel = new DialogWindowViewModel(dialogWindow);
        }

        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    dialogWindow.ViewModel.WindowMinimumWidth = WindowMinimumWidth;
                    dialogWindow.ViewModel.WindowMinimumHeight= WindowMinimumHeight;
                    dialogWindow.ViewModel.TitleHeight = TitleHeight;
                    dialogWindow.ViewModel.Title = viewModel.Title ?? Title;
                    dialogWindow.ViewModel.Content = this;
                    dialogWindow.Owner = Application.Current.MainWindow;
                    dialogWindow.WindowStartupLocation= WindowStartupLocation.CenterOwner;
                    DataContext = viewModel;

                    dialogWindow.ShowDialog();
                }
                finally
                {
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        public ICommand CloseCommand => new RelayCommand(dialogWindow.Close);
    }
}
