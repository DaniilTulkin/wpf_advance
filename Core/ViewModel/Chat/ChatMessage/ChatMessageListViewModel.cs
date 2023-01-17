using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace wpf_advance.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        public ObservableCollection<ChatMessageListItemViewModel> Items { get; set; }
        public bool AttachmentMenuVisible { get; set; }
        public bool AnyPopupVisible => AttachmentMenuVisible;
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; } = new ChatAttachmentPopupMenuViewModel();
        public string PendingMessageText { get; set; }

        public ICommand AttachButtonCommand => new RelayCommand(() =>
        {
            AttachmentMenuVisible ^= true;
        });
        public ICommand PopupClickAwayCommand => new RelayCommand(() =>
        {
            AttachmentMenuVisible = false;
        });
        public ICommand SendCommand => new RelayCommand(() =>
        {
            if (Items == null) Items= new ObservableCollection<ChatMessageListItemViewModel>();

            Items.Add(new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Jora",
                NewItem= true,
            });

            PendingMessageText = null;
        });
    }
}
