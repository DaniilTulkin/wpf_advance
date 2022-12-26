using System.Windows;

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

    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value) await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3, false);
            else await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3, false);
        }
    }
}
