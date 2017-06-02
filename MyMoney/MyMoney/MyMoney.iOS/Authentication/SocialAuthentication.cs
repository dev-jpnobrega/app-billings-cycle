using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

using MyMoney.Authentication;
using MyMoney.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MyMoney.iOS.Authentication.SocialAuthentication))]
namespace MyMoney.iOS.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient c, MobileServiceAuthenticationProvider p, IDictionary<string, string> param = null)
        {
            try
            {
                var current = GetController();
                var user = await c.LoginAsync(current, p);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            var current = root;
            while (current.PresentedViewController != null)
                current = current.PresentedViewController;

            return current;
        }
    }
}