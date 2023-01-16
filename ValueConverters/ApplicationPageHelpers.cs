using Microsoft.Win32;
using System;
using System.Globalization;
using wpf_advance.Core;

namespace wpf_advance
{
    public static class ApplicationPageHelpers
    {
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            return page switch
            {
                ApplicationPage.Login => new LoginPage(viewModel as LoginViewModel),
                ApplicationPage.Register => new RegisterPage(viewModel as RegisterViewModel),
                ApplicationPage.Chat => new ChatPage(viewModel as ChatMessageListViewModel),
                _ => null
            };
        }

        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            if (page is ChatPage) return ApplicationPage.Chat;
            else if  (page is LoginPage) return ApplicationPage.Login;
            else if(page is RegisterPage) return ApplicationPage.Register;
            return default;               
        }
    }
}
