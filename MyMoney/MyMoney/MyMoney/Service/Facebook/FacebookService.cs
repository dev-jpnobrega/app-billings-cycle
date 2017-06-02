using System;
using System.Threading.Tasks;
using MyMoney.Model;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;


[assembly: Xamarin.Forms.Dependency(typeof(MyMoney.Service.Facebook.FacebookService))]
namespace MyMoney.Service.Facebook
{
    public class FacebookService : IFacebookService
    {
        private string _Url = "https://graph.facebook.com/";
        private readonly string _TokenAcess = string.Empty;
        private readonly HttpClient HttpClient;


        public FacebookService()
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(_Url)
            };

            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<ImageSource> GetImageUserAsync(string uri) =>
            await Task.Factory.StartNew(() => ImageSource.FromUri(new Uri(uri)));

        public async Task<UserFacebookAuthentication> GetPublicPerfilAsync(string accessToken)
        {
            var response = await HttpClient.GetAsync($"me?access_token={accessToken}");

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    string result = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);

                    UserFacebookAuthentication u = JsonConvert.DeserializeObject<UserFacebookAuthentication>(result);
                    u.UrlPicture = $"https://graph.facebook.com/{u.UID}/picture?type=large";
                    return u;
                }
            }

            return null;
        }
    }
}
