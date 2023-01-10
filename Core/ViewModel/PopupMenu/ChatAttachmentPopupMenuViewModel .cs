using System.Collections.Generic;

namespace wpf_advance.Core
{
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        public ChatAttachmentPopupMenuViewModel()
        {
            Content = new MenuViewModel()
            {
                Items = new List<MenuItemViewModel>()
                {
                    new MenuItemViewModel()
                    {
                        Text = "Attach a file...",
                        Type = MenuItemType.Header
                    },
                    new MenuItemViewModel()
                    {
                        Text = "From computer",
                        Icon = IconType.File
                    },
                    new MenuItemViewModel()
                    {
                        Text = "From picture",
                        Icon = IconType.Picture
                    },
                }
            };
        }
    }
}
