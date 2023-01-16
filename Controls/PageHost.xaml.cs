using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using wpf_advance.Core;

namespace wpf_advance
{
    public partial class PageHost : UserControl
    {
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), 
                                        typeof(ApplicationPage), 
                                        typeof(PageHost), 
                                        new UIPropertyMetadata(default(ApplicationPage), null, CurrentPagePropertyChanged));

        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            var currentPage = d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;
            
            var oldPageContent = newPageFrame.Content;
            newPageFrame.Content = null;
            oldPageFrame.Content = oldPageContent;

            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }

            newPageFrame.Content = currentPage;
            return value;
        }

        public BaseViewModel CurrentPageViewModel
        {
            get { return (BaseViewModel)GetValue(CurrentPageViewModelProperty); }
            set { SetValue(CurrentPageViewModelProperty, value); }
        }

        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register("CurrentPageViewModel", typeof(BaseViewModel), typeof(PageHost), new PropertyMetadata());

        public PageHost()
        {
            InitializeComponent();
        }
    }
}
