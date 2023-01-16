using System;
using System.Windows;
using System.Windows.Controls;

namespace wpf_advance
{
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var panel = sender as Panel;
            SetWidth(panel);

            RoutedEventHandler onLoaded = null;
            onLoaded = (s, ee) =>
            {
                panel.Loaded -= onLoaded;
                SetWidth(panel);

                foreach (FrameworkElement child in panel.Children)
                {
                    if (!(child is TextEntryControl control)) continue;
                    control.Label.SizeChanged += (ss, eee) =>
                    {
                        SetWidth(panel);
                    };
                }
            };

            panel.Loaded += onLoaded;
        }

        private void SetWidth(Panel panel)
        {
            double maxSize = 0;

            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control)) continue;

                control.LabelWidth = GridLength.Auto;
                maxSize = Math.Max(maxSize, control.Label.RenderSize.Width + control.Label.Margin.Left + control.Label.Margin.Right);
            }

            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());
            foreach (var child in panel.Children)
            {
                if (!(child is TextEntryControl control)) continue;
                control.LabelWidth = gridLength;
            }
        }
    }
}
