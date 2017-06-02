using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

using MyMoney.Authentication;
using MyMoney.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MyMoney.Droid.Authentication.SocialAuthentication))]
namespace MyMoney.Droid.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient c, MobileServiceAuthenticationProvider p, IDictionary<string, string> param = null)
        {
            try
            {
                var user = await c.LoginAsync(Forms.Context, p);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}