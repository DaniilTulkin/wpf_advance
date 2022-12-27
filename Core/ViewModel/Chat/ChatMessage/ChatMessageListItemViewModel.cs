using System;

namespace wpf_advance.Core
{
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        public string SenderName { get; set; }
        public string Message { get; set; }
        public string Initials { get; set; }
        public string ProfilePictureRGB { get; set; }
        public bool IsSelected { get; set; }
        public bool SentByMe { get; set; }
        public DateTimeOffset MessageReadTime { get; set; }
        public DateTimeOffset MessageSentTime { get; set; }
        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;
    }
}
