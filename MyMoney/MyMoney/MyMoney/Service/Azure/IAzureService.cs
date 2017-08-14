using System.Threading.Tasks;

namespace MyMoney.Service.Azure
{
    public interface IAzureService
    {
        Task<bool> LoginAsync();
        Task<bool> LogoutAsync();
        Task<Newtonsoft.Json.Linq.JToken> GetInfoProvider(string path);
    }
}
