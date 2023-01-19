using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace wpf_advance
{
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {
        private RoutedEventHandler border_Loaded;
        private SizeChangedEventHandler border_SizeChanged;
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var self = sender as FrameworkElement;
            if (!(self.Parent is Border border))
            {
                Debugger.Break(); 
                return;
            }

            border_Loaded = (s1, e1) => Border_OnChanged(s1, e1, self);
            border_SizeChanged = (s1, e1) => Border_OnChanged(s1, e1, self);

            if ((bool)e.NewValue)
            {
                border.Loaded += border_Loaded;
                border.SizeChanged += border_SizeChanged;
            }
            else
            {
                border.Loaded -= border_Loaded;
                border.SizeChanged -= border_SizeChanged;
            }
        }

        private void Border_OnChanged(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            var border = (Border)sender;

            if (border.ActualWidth == 0 && border.ActualHeight == 0) return;

            var rect = new RectangleGeometry();
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left / 2));

            rect.Rect = new Rect(child.RenderSize);
            child.Clip = rect;
        }
    }
}
