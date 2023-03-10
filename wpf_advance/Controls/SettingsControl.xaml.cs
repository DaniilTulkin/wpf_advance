using Core;
using System.Windows.Controls;

namespace wpf_advance
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
            DataContext = IoC.Settings;
        }
    }
}
