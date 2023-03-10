using System.Windows;
using System.Windows.Controls;

namespace wpf_advance
{
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        public bool FirstLoad { get; set; } = true;
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (!(sender is FrameworkElement element)) return;
            if(sender.GetValue(ValueProperty) == value && 
               !FirstLoad) return;
            if (FirstLoad)
            {
                if (!(bool)value) element.Visibility = Visibility.Hidden;

                RoutedEventHandler onLoaded = null;
                onLoaded = (s, e) =>
                {
                    element.Loaded -= onLoaded;
                    DoAnimation(element, (bool)value);
                    FirstLoad = false;
                };
                element.Loaded += onLoaded;
            }
            else DoAnimation(element, (bool)value);
        }

        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    }
    public class FadeImageOnLoadProperty: AnimateBaseProperty<FadeImageOnLoadProperty>
    {
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            if (sender is Image image)
            {
                if ((bool)value) 
                    image.TargetUpdated += Image_TargetUpdatedAsync;
                else 
                    image.TargetUpdated -= Image_TargetUpdatedAsync;
            }
        }

        private async void Image_TargetUpdatedAsync(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            await (sender as Image).FadeInAsync();
        }
    }
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3, false);
            else await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3, false);
        }
    }
    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) await element.SlideAndFadeInFromRightAsync(FirstLoad ? 0 : 0.3, false);
            else await element.SlideAndFadeOutToRightAsync(FirstLoad ? 0 : 0.3, false);
        }
    }
    public class AnimateSlideInFromRightMarginProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) await element.SlideAndFadeInFromRightAsync(FirstLoad ? 0 : 0.3, true);
            else await element.SlideAndFadeOutToRightAsync(FirstLoad ? 0 : 0.3, true);
        }
    }
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3, false);
            else await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3, false);
        }
    }
    public class AnimateSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnLoadProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            await element.SlideAndFadeInFromBottomAsync(!value ? 0 : 0.3, false);
        }
    }
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3, true);
            else await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3, true);
        }
    }
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) await element.FadeInAsync(FirstLoad ? 0 : 0.3);
            else await element.FadeOutAsync(FirstLoad ? 0 : 0.3);
        }
    }
}
