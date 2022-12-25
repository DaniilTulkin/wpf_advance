using System.Collections.Generic;

namespace wpf_advance
{
    public class ChatListDisignModel : ChatListViewModel
    {
        public static ChatListDisignModel Instance => new ChatListDisignModel();

        public ChatListDisignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This chat app is awesome? I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true,
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jasse",
                    Message = "Hey dude, here are new icins",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true,
                },
                new ChatListItemViewModel
                {
                    Initials = "Pl",
                    Name = "Parnell",
                    Message = "The new server is up",
                    ProfilePictureRGB = "00d405",
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This chat app is awesome? I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jasse",
                    Message = "Hey dude, here are new icins",
                    ProfilePictureRGB = "fe4503",
                },
                new ChatListItemViewModel
                {
                    Initials = "Pl",
                    Name = "Parnell",
                    Message = "The new server is up",
                    ProfilePictureRGB = "00d405",
                },
                new ChatListItemViewModel
                {
                    Initials = "LM",
                    Name = "Luke",
                    Message = "This chat app is awesome? I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                },
                new ChatListItemViewModel
                {
                    Initials = "JA",
                    Name = "Jasse",
                    Message = "Hey dude, here are new icins",
                    ProfilePictureRGB = "fe4503",
                },
                new ChatListItemViewModel
                {
                    Initials = "Pl",
                    Name = "Parnell",
                    Message = "The new server is up",
                    ProfilePictureRGB = "00d405",
                },
            };
        }
    }
}
