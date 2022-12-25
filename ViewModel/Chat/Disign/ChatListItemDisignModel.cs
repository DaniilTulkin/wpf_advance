namespace wpf_advance
{
    public class ChatListItemDisignModel : ChatListItemViewModel
    {
        public static ChatListItemDisignModel Instance => new ChatListItemDisignModel();

        public ChatListItemDisignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This chat app is awesome? I bet it will be fast too";
            ProfilePictureRGB = "3099c5";
        }
    }
}
