using System.Windows;

namespace wpf_advance
{
    public partial class DialogWindow : Window
    {
        private DialogWindowViewModel viewModel;
        public DialogWindowViewModel ViewModel
        {
            get => viewModel;
            set
            {
                viewModel = value;
                DataContext= viewModel;
            }
        }
        public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
