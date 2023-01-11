using System.Threading.Tasks;

namespace wpf_advance.Core
{
    public interface IUIMenager
    {
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}
