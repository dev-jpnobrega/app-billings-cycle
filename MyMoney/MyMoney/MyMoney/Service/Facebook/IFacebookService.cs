using MyMoney.Model;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMoney.Service.Facebook
{
    public interface IFacebookService
    {
        Task<UserFacebookAuthentication> GetPublicPerfilAsync(string accessToken);

        Task<ImageSource> GetImageUserAsync(string uri);
    }
}
