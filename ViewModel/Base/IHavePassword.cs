using System.Security;

namespace wpf_advance
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}
