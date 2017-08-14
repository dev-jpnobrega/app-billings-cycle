using Microsoft.WindowsAzure.MobileServices;
using MyMoney.Authentication;
using MyMoney.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(MyMoney.UWP.Authentication.SocialAuthentication))]
namespace MyMoney.UWP.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient c, MobileServiceAuthenticationProvider p, IDictionary<string, string> param = null)
        {
            try
            {
                var user = await c.LoginAsync(p);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> LogoutAsync(MobileServiceClient client, IDictionary<string, string> parameters = null)
        {
            try
            {
               // CookieManager.Instance.RemoveAllCookie();
                await client.LogoutAsync();
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Log error
                throw;
            }
        }
    }
}
