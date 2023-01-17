using System.Windows.Media.Animation;
using wpf_advance.Core;

namespace wpf_advance
{
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        public ChatPage() : base()
        {
            InitializeComponent();
        }
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        protected override void OnViewModelChanged()
        {
            if (ChatMessageList != null)
            {
                var storyboard = new Storyboard();
                storyboard.AddFadeIn(1);
                storyboard.Begin(ChatMessageList);
            }
        }
    }
}
