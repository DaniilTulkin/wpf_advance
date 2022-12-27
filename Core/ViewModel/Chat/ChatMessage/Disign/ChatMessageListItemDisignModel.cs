using System;

namespace wpf_advance.Core
{
    public class ChatMessageListItemDisignModel : ChatMessageListItemViewModel
    {
        public static ChatMessageListItemDisignModel Instance => new ChatMessageListItemDisignModel();

        public ChatMessageListItemDisignModel()
        {
            Initials = "LM";
            SenderName = "Luke";
            Message = "Some disgn time visual text";
            ProfilePictureRGB = "3099c5";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }
    }
}
