using System.Collections.Generic;

namespace wpf_advance.Core
{
    public class MenuDisignModel : MenuViewModel
    {
        public static MenuDisignModel Instance = new MenuDisignModel();
        public MenuDisignModel()
        {
            Items = new List<MenuItemViewModel>()
            {
                new MenuItemViewModel
                {
                    Type = MenuItemType.Header,
                    Text = "Attach a file"
                },
                new MenuItemViewModel
                {
                    Text = "From computer",
                    Icon = IconType.File
                },
                new MenuItemViewModel
                {
                    Text = "From pictures",
                    Icon = IconType.Picture
                }
            };
        }
    }
}
