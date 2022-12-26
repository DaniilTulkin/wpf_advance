using System;
using System.Windows;

namespace wpf_advance
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent : BaseAttachedProperty<Parent, Property>, new()
    {
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender,e) => { };
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };
        public static Parent Instance { get; private set; } = new Parent();
        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.RegisterAttached("Value", 
                                                typeof(Property), 
                                                typeof(BaseAttachedProperty<Parent, Property>), 
                                                new PropertyMetadata(
                                                    default(Property),
                                                    new PropertyChangedCallback(OnValuePropertyChanged),
                                                    new CoerceValueCallback(OnValuePropertyUpdated)));

        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            Instance.OnValueUpdated(d, value);
            Instance.ValueUpdated(d, value);
            return value;
        }

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d, e);
            Instance.ValueChanged(d, e);
        }
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }
    }
}
