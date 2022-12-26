using Core;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf_advance.Core
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public bool LoginIsRunning { get; set; }

        public ICommand LoginCommand => new RelayParameterizedCommand( async (parameter) =>
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                string email = Email;
                string pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        });
        public ICommand RegisterCommand => new RelayCommand(async () =>
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;
            await Task.Delay(1000);
        });
    }
}
