using Core;
using System.Security;
using System.Windows.Input;

namespace wpf_advance.Core
{
    public class PasswordEntryViewModel : BaseViewModel
    {
        public string Label { get; set; }
        public string FakePassword { get; set; }
        public string CurrentPasswordHintText { get; set; } = "Current password";
        public string NewPasswordHintText { get; set; } = "New password";
        public string ConfirmPasswordHintText { get; set; } = "Confirm password";
        public SecureString CurrentPassword { get; set; }
        public SecureString NewPassword { get; set; }
        public SecureString ConfirmPassword { get; set; }
        public bool Editing { get; set; }

        public ICommand Edit => new RelayCommand(() =>
        {
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();
             
            Editing = true;
        });
        public ICommand Cancel => new RelayCommand(() => Editing = false);
        public ICommand Save => new RelayCommand(() =>
        {
            var storedPassword = "Testing";
            if (storedPassword != CurrentPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password",
                    Message = "The current password isn't valid"
                });
                return;
            }

            if (NewPassword.Unsecure().Length == 0)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password too short",
                    Message = "You must enter password"
                });
                return;
            }

            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);
            Editing = false;
        });
    }
}
