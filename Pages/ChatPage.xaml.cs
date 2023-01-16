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
    }
}
