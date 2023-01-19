using System.Security;
using wpf_advance.Core;

namespace wpf_advance
{
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        public RegisterPage(RegisterViewModel spicificViewModel) : base(spicificViewModel)
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
