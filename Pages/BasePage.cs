using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using wpf_advance.Animations;

namespace wpf_advance
{
    public class BasePage<VM> : Page
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
        public PageAnimation PageLoadAnimation  { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation  { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public double SlideSeconds { get; set; } = 0.8;

        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_Loaded;
            ViewModel = new VM();
        }

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateIn();
        }
        public async Task AnimateIn()
        {
            if (PageLoadAnimation == PageAnimation.None) return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSeconds);
                    break;
                default:
                    break;
            }
        }
        public async Task AnimateOut()
        {
            if (PageUnloadAnimation == PageAnimation.None) return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSeconds);
                    break;
                default:
                    break;
            }
        }
    }
}
