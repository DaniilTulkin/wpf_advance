using System.ComponentModel;

namespace wpf_advance.Core
{
    public class TextEntryDisignModel : TextEntryViewModel
    {
        public static TextEntryDisignModel Instance = new TextEntryDisignModel();
        public TextEntryDisignModel()
        {
            Label = "test";
            OriginalText= "test";
        }
    }
}
