using System;
using BCrypt.Net;
using Newtonsoft.Json;
using Xamarin.Auth;
using System.Threading.Tasks;

namespace neo.pcl
{
    internal class TagAuthenticator
    {
        #region methods
        public async void SignUpAsync(TagPersonModel tagPerson)
        {
            // we got couple of steps
            // 1: we need to hash the password with the salt and send it back to reg backend
            tagPerson.password = DependencyInjector.instance.Resolve<ICryptoService>().HashPassword(tagPerson.password, tagPerson.id);
            var res = await DependencyInjector.instance.Resolve<IRestService>().PostAsync<TagPersonModel, TagResponseModel>
                (
                    Consts.EMULATOR_REST_ENDPOINT + "/reg", tagPerson
                );
            // 2: if Signing up was successful
            if (res.finished == "OK")
            {
                await AccountStore.Create().SaveAsync(new Account(tagPerson.password), "TagAuth");
            }
            else
            {
                // #revise
            }
        }
        public async Task AuthenticateAsync(string username, string hashedPass)
        {
            // we should use the stored hashedPass to authenticate the current user
            if (string.IsNullOrEmpty(hashedPass))
            {
                await Acr.UserDialogs.UserDialogs.Instance.AlertAsync("باید دوباره به برنامه وارد شوید", Consts.PR_OKAY_TEXT);
                //await DependencyInjector.instance.Resolve<INavigationService>().NavigateToAsync<LoginPageVM>();
            }
            else
            {
                var res = await DependencyInjector.instance.Resolve<IRestService>().PostAsync<TagQueryModel, TagResponseModel>
                (
                    Consts.EMULATOR_REST_ENDPOINT + "/login",
                    new TagQueryModel(query: new Func<string>(() =>
                    {
                        var tp = new TagPersonModel();
                        tp.id = username;
                        tp.password = hashedPass;
                        return tp.ToString();
                    }).Invoke())
                );
                if (res.finished == "OK")
                {
                    // #revise
                }
                else
                {
                    // #revise
                }
            }
        }
        public async void LoginUser(string username, string password)
        {
            var hp = DependencyInjector.instance.Resolve<ICryptoService>().HashPassword(password, username);
            await AuthenticateAsync(username, password);
            
        }
        #endregion
    }
}