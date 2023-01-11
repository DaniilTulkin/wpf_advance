namespace wpf_advance.Core
{
    public static class IconTypeToFontAwesome
    {
        public static string ToFontAwesome(this IconType type)
        {
            return type switch
            {
                IconType.File => "\uf0f6",
                IconType.Picture => "\uf1c5",
                _ => null
            };
        }
    }
}
