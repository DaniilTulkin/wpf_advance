using System.Windows;
using System.Windows.Controls;

namespace wpf_advance
{
    public class DialogWindowViewModel : WindowViewModel
    {
        public string Title { get; set; }
        public Control Content { get; set; }
        public DialogWindowViewModel(Window window) : base(window) 
        {
            WindowMinimumWidth = 250;
            WindowMinimumHeight = 100;
            TitleHeight = 30;
        }
    }
}
