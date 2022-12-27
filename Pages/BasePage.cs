using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using wpf_advance.Core;

namespace wpf_advance
{
    public class BasePage: Page
    {
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public double SlideSeconds { get; set; } = 0.4;
        public bool ShouldAnimateOut { get; set; }

        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_LoadedAsync;
        }

        private async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {
            if (ShouldAnimateOut) await AnimateOutAsync();
            else await AnimateInAsync();
        }
        public async Task AnimateInAsync()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);
                    break;
                default:
                    break;
            }
        }
        public async Task AnimateOutAsync()
        {
            if (PageUnloadAnimation == PageAnimation.None) return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);
                    break;
                default:
                    break;
            }
        }
    }
    public class BasePage<VM> : BasePage
        where VM : BaseViewModel, new()
    {
        private VM viewModel;
        public VM ViewModel
        {
            get
            {
                return viewModel;
            }
            set
            {
                if (viewModel == value) return;
                viewModel = value;

                DataContext = viewModel;
            }
        }

        public BasePage() : base()
        {
            ViewModel = new VM();
        }
    }
}
