using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMoney.Authentication
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient c, MobileServiceAuthenticationProvider p, IDictionary<string, string> param = null);
    }
}
