using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tag.Core.Pages;
using Xamarin.Auth;
using Xamarin.Forms;
namespace Tag.Core
{
    public class AuthenticationService : IAuthenticationService
    {
        AccountStore accStore = AccountStore.Create();
        OAuth2Authenticator googleAuthenticator, fbAuthenticator, twitterAuthenticator;
        public OAuth2Authenticator CurrentAuthenticator { get; set; }
        TagAuthenticator tagAuthenticator;
        Xamarin.Auth.XamarinForms.AuthenticatorPage login_page = null;



        // methods
        #region Tag Auth
            private async Task InitTagAuthenticator()
        {

        }
        #endregion
        #region Xam Auth
            private void NavigateLoginPage(OAuth2Authenticator authenticator)
        {
            // / *
            //---------------------------------------------------------------------
            // ContentPage with CustomRenderers
            login_page = new Xamarin.Auth.XamarinForms.AuthenticatorPage()
            {
                Authenticator = authenticator,
            };
            DependencyInjector.instance.Resolve<NavigationService>().Navigation.PushAsync(login_page);
            //---------------------------------------------------------------------
            // Xamarin.UNiversity Team Presenters Concept
            // Xamarin.Auth.Presenters.OAuthLoginPresenter presenter = null;
            // presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            //presenter.Login (authenticator);
            //---------------------------------------------------------------------
            // * /

            return;
        }
        #endregion

        #region gOauth

            public async Task InitGoogleAuthenticator()
        {
            if (googleAuthenticator == null)
            {
                googleAuthenticator = new OAuth2Authenticator(
                    clientId: new Func<string>(() =>
                   {
                       string retCID = "not defined";
                       switch (Device.RuntimePlatform)
                       {
                           case "Android":
                               retCID = Consts.GAuthAndroidClientID;
                               break;
                           case "iOS":
                               retCID = Consts.GAuthiOSClientID;
                               break;
                           case "Windows":
                               retCID = Consts.GAuthWindowsClientID;
                               break;
                           default:
                               break;
                       }
                       return retCID;
                   }).Invoke(),
                    clientSecret: null,
                    scope: Consts.GAuthScope,
                    authorizeUrl: new Uri(Consts.GAuthAuthorizeUrl),
                    redirectUrl: new Func<Uri>(() =>
                   {
                       string retUri = null;
                       switch (Xamarin.Forms.Device.RuntimePlatform)
                       {
                           case "Android":
                               retUri =
                                    Consts.GAuthAndroidRedirectUrl;
                               break;
                           case "iOS":
                               retUri =
                                    Consts.GAuthiOSRedirectUrl;
                               break;
                           case "Windows":
                               retUri =
                                    Consts.GAuthWindowsRedirectUrl;
                               break;
                       }
                       return new Uri(retUri);
                   }).Invoke(),

                    accessTokenUrl: new Uri(Consts.GAuthAccessTokenUrl),
                    getUsernameAsync: null,
                    isUsingNativeUI: true);
                googleAuthenticator.AllowCancel = true;
                googleAuthenticator.Completed += async (sender, e) =>
                {
                    if (e.IsAuthenticated)
                    {
                        string googleProfileResponse = null;
                        OAuth2Request request = new OAuth2Request
                                (
                                    "GET",
                                     new Uri(" https://www.googleapis.com/oauth2/v1/userinfo"),
                                     null,
                                     e.Account
                                );
                        await request.GetResponseAsync().ContinueWith
                        (
                           async t =>
                           {
                               if (t.IsFaulted)
                               {
                                   await UserDialogs.Instance.AlertAsync(Consts.PR_CONNECTION_ERROR_TEXT, Consts.PR_OKAY_TEXT);
                                   Debug.WriteLine("Error: " + t.Exception.InnerException.Message);
                               }
                               else
                               {
                                   googleProfileResponse = t.Result.GetResponseText();
                                   AccountStore.Create().Save(e.Account, "GoogleAuth");
                                   Debug.WriteLine(googleProfileResponse);
                               }
                           }
                        );
                        //await DependencyInjector.instance.Resolve<INavigationService>().NavigateToAsync<SignUpPageVM>(new object[] { e.Account, googleProfileResponse });
                    }
                    else
                    {
                        // The user cancelled
                    }
                };
                googleAuthenticator.Error += async (sender, e) =>
                {
                    await UserDialogs.Instance.AlertAsync(e.Exception.ToString(), Consts.PR_OKAY_TEXT);
                    return;
                };
            }
            //new Xamarin.Auth.Presenters.OAuthLoginPresenter().Login(googleAuthenticator);
            CurrentAuthenticator = googleAuthenticator;
            NavigateLoginPage(googleAuthenticator);
            return;
        }
        #endregion

        public void InitFacebookAuthenticator()
        {
            throw new NotImplementedException();
        }

        public void InitTwitterAuthenticator()
        {
            throw new NotImplementedException();
        }

        // maybe later, we think of a different way of checking previous auth. for now we just SaveAuthToken to disk.
        public bool IsAuthenticated () 
        {
            // 1: we check if we have any accouts on xam.auth.accountstore
            var tagAuth = accStore.FindAccountsForService("TagAuth").FirstOrDefault();
            var gOauth = accStore.FindAccountsForService("GoogleAuth").FirstOrDefault();
            var fbAuth = accStore.FindAccountsForService("FacebookAuth").FirstOrDefault();
            var twtrAuth = accStore.FindAccountsForService("TwitterAuth").FirstOrDefault();
            if (tagAuth != null)
            {
                // some
                return true;
            }
            else if (gOauth != null)
            {
                return true;
            }
            else if (fbAuth != null)
            {
                return true;
            }
            else if (twtrAuth != null)
            {
                return true;
            }
            return false;
        }
        //{
        //    bool tokenOnDisk = await CheckIfTokenIsOnTheDisk();
        //    if (!tokenOnDisk)
        //    {
        //        // we have to Authorize the user, perhaps he's a new user or someone who has lost his credentials for any reason.

        //    }
        //    else
        //    {
        //        return true;
        //    }
        //    // #test
        //    return true;
        //}

    }
    //    public class AuthenticationService : IAuthenticationService
    //    {
    //        private readonly IRequestProvider _requestProvider;

    //        public bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);

    //        public AuthenticationService(IRequestProvider requestProvider)
    //        {
    //            _requestProvider = requestProvider;
    //        }

    //        public async Task<bool> LoginAsync(string userName, string password)
    //        {
    //            var auth = new AuthenticationRequest
    //            {
    //                UserName = userName,
    //                Credentials = password,
    //                GrantType = "password"
    //            };

    //            UriBuilder builder = new UriBuilder(GlobalSettings.AuthenticationEndpoint);
    //            builder.Path = "api/login";

    //            string uri = builder.ToString();

    //            AuthenticationResponse authenticationInfo = await _requestProvider.PostAsync<AuthenticationRequest, AuthenticationResponse>(uri, auth);
    //            Settings.UserId = authenticationInfo.UserId;
    //            Settings.ProfileId = authenticationInfo.ProfileId;
    //            Settings.AccessToken = authenticationInfo.AccessToken;

    //            return true;
    //        }

    //        public Task LogoutAsync()
    //        {
    //            Settings.RemoveUserId();
    //            Settings.RemoveProfileId();
    //            Settings.RemoveAccessToken();
    //            Settings.RemoveCurrentBookingId();

    //            return Task.FromResult(false);
    //        }

    //        public int GetCurrentUserId()
    //        {
    //            return Settings.UserId;
    //        }
    //    }
}

