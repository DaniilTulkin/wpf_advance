using System.Windows;

namespace wpf_advance
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
        }
    }
}
