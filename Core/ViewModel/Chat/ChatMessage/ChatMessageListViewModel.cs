using System.Collections.Generic;
using System.Windows.Input;

namespace wpf_advance.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        public List<ChatMessageListItemViewModel> Items { get; set; }
        public bool AttachmentMenuVisible { get; set; }
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; } = new ChatAttachmentPopupMenuViewModel();

        public ICommand AttachButtonCommand => new RelayCommand(() =>
        {
            AttachmentMenuVisible ^= true;
        });
    }
}
