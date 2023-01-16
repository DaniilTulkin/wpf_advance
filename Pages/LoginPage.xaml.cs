using System.Security;
using wpf_advance.Core;

namespace wpf_advance
{
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        public LoginPage(LoginViewModel spicificViewModel) : base(spicificViewModel) 
        {
            InitializeComponent();
        }
        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
