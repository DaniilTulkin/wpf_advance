using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace wpf_advance
{
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = sender as Frame;
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frame.Navigated += (s, e) => ((Frame)s).NavigationService.RemoveBackEntry();
        }
    }
}
