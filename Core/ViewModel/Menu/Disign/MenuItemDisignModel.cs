namespace wpf_advance.Core
{
    public class MenuItemDisignModel : MenuItemViewModel
    {
        public static MenuItemDisignModel Instance = new MenuItemDisignModel();
        public MenuItemDisignModel()
        {
            Text = "Hello World";
            Icon = IconType.File;
        }
    }
}
