using System.Threading.Tasks;
using System.Windows.Input;

namespace wpf_advance
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public bool LoginIsRunning { get; set; }

        public LoginViewModel()
        {
           
        }

        public ICommand LoginCommand => new RelayParameterizedCommand( async (parameter) => await Login(parameter));
        private async Task Login(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                await Task.Delay(5000);

                string email = Email;
                string pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }
    }
}
