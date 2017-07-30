using System.Threading.Tasks;
using Xamarin.Auth;

namespace Tag.Core
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated();
        Task InitGoogleAuthenticator();
        void InitFacebookAuthenticator();
        void InitTwitterAuthenticator();

        //Task<bool> LoginAsync(string userName, string password);

        //Task LogoutAsync();

        //int GetCurrentUserId();
    }
}
