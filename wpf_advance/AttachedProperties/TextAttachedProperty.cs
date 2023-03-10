using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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
    public class FocuseAndSelectProperty : BaseAttachedProperty<FocuseAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is TextBoxBase control)
            {
                if ((bool)e.NewValue)
                {
                    control.Focus();
                    control.SelectAll();
                }
            }

            if (sender is PasswordBox password)
            {
                if ((bool)e.NewValue)
                {
                    password.Focus();
                    password.SelectAll();
                }
            }
        }
    }
}
