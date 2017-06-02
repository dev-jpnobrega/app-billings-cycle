using MyMoney.Helpers;
using MyMoney.Model;
using MyMoney.Service.Azure;
using MyMoney.Service.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMoney.ViewModel
{
    public class MainPageViewModel: BaseViewModel
    {
        readonly IFacebookService _IFacebookService;
        readonly IAzureService _IAzureService;

        public Command LoginFacebookCommand { get; }


        public MainPageViewModel()
        {
            Title = "My Money App";
            IsBusy = false;

            _IFacebookService = DependencyService.Get<IFacebookService>();
            _IAzureService = DependencyService.Get<IAzureService>();
            
            LoginFacebookCommand = new Command(ExecuteLoginFacebookCommand);
        }

        async void ExecuteLoginFacebookCommand()
        {
            IsBusy = true;
            if (await LoginAsync())
            {
                IsBusy = false;
                try
                {
                    Application.Current.MainPage = new MyMoney.View.MD.MasterDetailContainerPage();
                }
                catch (Exception ex)
                {

                    throw;
                }
               
            }
        }
        
        public async Task<bool> LoginAsync()
        {
            bool r = false;
            r = Settings.IsLoggedIn;

            if (!Settings.IsLoggedIn)
                r = await _IAzureService.LoginAsync();

            if (!r) return false;

            Newtonsoft.Json.Linq.JToken j = await _IAzureService.GetInfoProvider("/.auth/me");
            Settings.TokenAuthFacebook = j[0].Value<string>("access_token");

            UserFacebookAuthentication us = await _IFacebookService.GetPublicPerfilAsync(Settings.TokenAuthFacebook);
            User.Email = us.Email;
            User.UrlPicture = us.UrlPicture;
            User.UID = us.UID;
            User.FirstName = us.FirstName;
            User.LastName = us.LastName;

            return true;
        }
    }
}
