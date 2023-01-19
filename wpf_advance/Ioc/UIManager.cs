using System.Threading.Tasks;
using wpf_advance.Core;

namespace wpf_advance
{
    public class UIManager : IUIMenager
    {
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }
    }
}
