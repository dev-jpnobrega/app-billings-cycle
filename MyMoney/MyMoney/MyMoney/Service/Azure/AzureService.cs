using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

using MyMoney.Helpers;
using MyMoney.Authentication;
using MyMoney.Model;
using MyMoney.Service.Azure;

[assembly: Xamarin.Forms.Dependency(typeof(MyMoney.Service.Azure.AzureService))]
namespace MyMoney.Service.Azure
{
    public class AzureService : IAzureService
    {
        static readonly string AppUrl = Settings.UrlAppAzure;

        public MobileServiceClient Client { get; set; } = null;
        public static bool UseAuth { get; set; } = false;


        public void Initialize()
        {
            if (Client != null) return;

            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await MyMoney.App.Current.MainPage.DisplayAlert("OPS!", "Não conseguimos efetuar o login.", "OK");
                });

                return false;
            }

            Settings.AuthToken = user.MobileServiceAuthenticationToken;
            Settings.UserId = user.UserId;

            return true;
        }

        public async Task<bool> LogoutAsync()
        {
            if (!Settings.IsLoggedIn) return true;

            Initialize();

            try
            {
                var auth = DependencyService.Get<IAuthentication>();

                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;
                Settings.TokenAuthFacebook = string.Empty;

                return await auth.LogoutAsync(Client, null);
            }
            catch (Exception ex)
            {

                throw;
            }            
        }


        public async Task<Newtonsoft.Json.Linq.JToken> GetInfoProvider(string path)
        {
            Initialize();
            try
            {
                return await Client.InvokeApiAsync(path, System.Net.Http.HttpMethod.Get, null);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

