using Core;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf_advance.Core
{
    public class RegisterViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public bool RegisterIsRunning { get; set; }

        public ICommand RegisterCommand => new RelayParameterizedCommand( async (parameter) =>
        {
            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);

                string email = Email;
                string pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        });
        public ICommand LoginCommand => new RelayCommand(async () =>
        {
            IoC.Application.GoToPage(ApplicationPage.Login);
            await Task.Delay(1000);
        });
    }
}
