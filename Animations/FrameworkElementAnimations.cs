using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace wpf_advance
{
    public static class FrameworkElementAnimations
    {
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, 
                                                              double seconds = 0.3,
                                                              bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, 
                                                             double seconds = 0.3,
                                                             bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, 
                                                            double seconds = 0.3,
                                                            bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, 
                                                             double seconds = 0.3,
                                                             bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeInFromBottomAsync(this FrameworkElement element,
                                                               double seconds = 0.3,
                                                               bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideFromBottom(seconds, element.ActualHeight, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task SlideAndFadeOutToBottomAsync(this FrameworkElement element,
                                                              double seconds = 0.3,
                                                              bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideToBottom(seconds, element.ActualHeight, keepMargin: keepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task FadeInAsync(this FrameworkElement element,
                                             double seconds = 0.3)
        {
            var sb = new Storyboard();
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
        public static async Task FadeOutAsync(this FrameworkElement element,
                                              double seconds = 0.3)
        {
            var sb = new Storyboard();
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
            element.Visibility = Visibility.Collapsed;
        }
    }
}
