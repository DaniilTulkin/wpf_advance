using System;
using System.Runtime.InteropServices;
using System.Security;

namespace wpf_advance.Core
{
    public static class SecureStringHelper
    {
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null) return string.Empty;

            var unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
