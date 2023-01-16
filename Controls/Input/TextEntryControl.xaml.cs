using System.Windows;
using System.Windows.Controls;

namespace wpf_advance
{
    public partial class TextEntryControl : UserControl
    {
        public GridLength LabelWidth
        {
            get { return (GridLength)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(TextEntryControl), new PropertyMetadata(GridLength.Auto, LabelWidthChanged));

        private static void LabelWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch
            {
                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        public TextEntryControl()
        {
            InitializeComponent();
        }
    }
}
