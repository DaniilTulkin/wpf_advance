using System.Windows.Input;

namespace wpf_advance.Core
{
    public class TextEntryViewModel : BaseViewModel
    {
        public string Label { get; set; }
        public string OriginalText { get; set; }
        public string EditedText { get; set; }
        public bool Editing { get; set; }

        public ICommand Edit => new RelayCommand(() =>
        {
            EditedText = OriginalText;
            Editing = true;
        });
        public ICommand Cancel => new RelayCommand(() => Editing = false);
        public ICommand Save => new RelayCommand(() =>
        {
            OriginalText = EditedText;
            Editing = false;
        });
    }
}
