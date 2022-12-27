using System;
using System.Collections.Generic;

namespace wpf_advance.Core
{
    public class ChatMessageListDisignModel : ChatMessageListViewModel
    {
        public static ChatMessageListDisignModel Instance => new ChatMessageListDisignModel();

        public ChatMessageListDisignModel()
        {
            Items = new List<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    Initials = "PL",
                    SenderName = "Parnell",
                    Message = "I'm about to wipe the old server. We need to update the old server to Wondows 2016",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "Lm",
                    SenderName = "Luke",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "PL",
                    SenderName = "Parnell",
                    Message = "The new server is up. Go to 192.168.1.1. Username is admin, password is P8ssw0rd!",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false
                },
            };
        }
    }
}
