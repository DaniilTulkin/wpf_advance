using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace wpf_advance.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        protected string lastSearchText;
        protected string searchText;
        protected ObservableCollection<ChatMessageListItemViewModel> items;
        protected bool searchIsOpen;
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => items;
            set
            {
                if (items != value)
                {
                    items = value;
                    FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(items);
                }
            }
        }
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }
        public bool AttachmentMenuVisible { get; set; }
        public bool AnyPopupVisible => AttachmentMenuVisible;
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; } = new ChatAttachmentPopupMenuViewModel();
        public string PendingMessageText { get; set; }
        public string DisplayTitle { get; set; }
        public string SearchText
        {
            get => searchText;
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                    if (string.IsNullOrEmpty(SearchText))
                        Search.Execute(null);
                }
            }
        }
        public bool SearchIsOpen
        {
            get => searchIsOpen;
            set
            {
                if (searchIsOpen != value)
                {
                    searchIsOpen = value;
                }

                if (searchIsOpen)
                    SearchText = string.Empty;
            }
        }

        public ICommand OpenSearch => new RelayCommand(() => SearchIsOpen = true);
        public ICommand Search => new RelayCommand(() =>
        {
            if ((string.IsNullOrEmpty(lastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(lastSearchText, SearchText)) return;

            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);
                lastSearchText= SearchText;
                return;
            }
            
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items.Where(item => item.Message.ToLower().Contains(SearchText.ToLower())));
            lastSearchText = SearchText;
        });
        public ICommand CloseSearch => new RelayCommand(() => SearchIsOpen = false);
        public ICommand ClearSearch => new RelayCommand(() =>
        {
            if (!string.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            else 
                SearchIsOpen = false;
        });
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
            if (string.IsNullOrEmpty(PendingMessageText)) 
                return;

            if (Items == null) Items= new ObservableCollection<ChatMessageListItemViewModel>();
            if (FilteredItems == null) Items= new ObservableCollection<ChatMessageListItemViewModel>();

            var message = (new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Jora",
                NewItem= true,
            });

            Items.Add(message);
            FilteredItems.Add(message);

            PendingMessageText = null;
        });
    }
}
