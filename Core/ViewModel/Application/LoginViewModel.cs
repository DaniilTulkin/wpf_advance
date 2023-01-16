using Core;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

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
                await Task.Delay(1000);

                IoC.Settings.Name = new TextEntryViewModel
                {
                    Label = "Name",
                    OriginalText = $"Name {DateTime.Now.ToLocalTime()}"
                };

                IoC.Settings.UserName = new TextEntryViewModel
                {
                    Label = "UserName",
                    OriginalText = "UserName",
                };

                IoC.Settings.Password = new PasswordEntryViewModel
                {
                    Label = "Password",
                    FakePassword = "********",
                };

                IoC.Settings.Email = new TextEntryViewModel
                {
                    Label = "Email",
                    OriginalText = "Email",
                };

                IoC.Application.GoToPage(ApplicationPage.Chat);
            });
        });
        public ICommand RegisterCommand => new RelayCommand(async () =>
        {
            IoC.Application.GoToPage(ApplicationPage.Register);
            await Task.Delay(1000);
        });
    }
}
