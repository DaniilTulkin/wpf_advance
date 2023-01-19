using System.Windows;
using System.Windows.Controls;
using wpf_advance.Core;

namespace wpf_advance
{
    public partial class PasswordEntryControl : UserControl
    {
        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(PasswordEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChanged));

        private static void LabelWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as PasswordEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch
            {
                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        public PasswordEntryControl()
        {
            InitializeComponent();
        }

        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;
        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.NewPassword = NewPassword.SecurePassword;
        }

        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;
        }
    }
}
