using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using wpf_advance.Core;
using Core;

namespace wpf_advance
{
    public class BasePage: Page
    {
        private object viewModel;
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;
        public double SlideSeconds { get; set; } = 0.4;
        public bool ShouldAnimateOut { get; set; }
        public object ViewModelObject
        {
            get
            {
                return viewModel;
            }
            set
            {
                if (viewModel == value) return;
                viewModel = value;

                OnViewModelChanged();
                DataContext = viewModel;
            }
        }

        public BasePage()
        {
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_LoadedAsync;
        }

        protected virtual void OnViewModelChanged() { }

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
        public VM ViewModel
        {
            get => (VM)ViewModelObject; 
            set => ViewModelObject = value;
        }
        public BasePage() : base()
        {
            ViewModel = IoC.Get<VM>();
        }

        public BasePage(VM specificViewModel = null) : base()
        {
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
                ViewModel = IoC.Get<VM>();
        }
    }
}
