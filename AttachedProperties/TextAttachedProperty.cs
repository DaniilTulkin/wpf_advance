using System.Windows;
using System.Windows.Controls;

namespace wpf_advance
{
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            base.OnValueChanged(sender, e);
            {
                if (!(sender is Control control)) return;
                control.Loaded += (s, e) => control.Focus();
            }
        }
    }
}
