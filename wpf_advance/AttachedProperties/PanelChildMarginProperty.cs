using System.Windows;
using System.Windows.Controls;

namespace wpf_advance
{
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = sender as Panel;
            panel.Loaded += (s, ee) =>
            {
                foreach (FrameworkElement child in panel.Children)
                {
                    child.Margin = (Thickness)new ThicknessConverter().ConvertFromString(e.NewValue as string);
                }
            };
        }
    }
}
