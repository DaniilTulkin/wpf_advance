using System.Security;

namespace wpf_advance.Core
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
