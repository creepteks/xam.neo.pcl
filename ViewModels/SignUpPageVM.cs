using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Acr.UserDialogs;
using Plugin.Media;
using Newtonsoft.Json;

namespace neo.pcl
{
    class SignUpPageVM: ViewModelBase
    {
        #region Bindable fields
        private string _userImagePath = new Func<string>(() =>
       {
           string retVal = null;
           switch (Device.RuntimePlatform)
           {
               case "Android":
                   retVal =  "icon";
                   break;
               case "iOS":
                   retVal = "some"; // #test
                   break;
                case "Windows":
                   retVal = "some";
                   break;
               default:
                   break;
           }
           return retVal;
       }).Invoke();
        public string UserImagePath
        {
            get { return _userImagePath; }
            set
            {
                _userImagePath = value;
                RaisePropertyChanged(() => UserImagePath);
            }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }
        private string _userCellNumber = "09";

        public string UserCellNumber
        {
            get { return _userCellNumber; }
            set
            {
                _userCellNumber = value;
                RaisePropertyChanged(() => UserCellNumber);
            }
        }
        private string _userEmail;

        public string UserEmail
        {
            get { return _userEmail; }
            set
            {
                _userEmail = value;
                RaisePropertyChanged(() => UserEmail);
            }
        }

        private string _userPassword;

        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                RaisePropertyChanged(() => UserPassword);
            }
        }
        #endregion

        #region methods
        public override Task InitializeAsync(object navigationData)
        { 
            try
            {
                ThirdPartyAuthModel trdPtyAuthMdl = JsonConvert.DeserializeObject<ThirdPartyAuthModel>(navigationData as string);
                UserImagePath = trdPtyAuthMdl.ProfilePicture;
                UserName = trdPtyAuthMdl.Name;
                return Task.FromResult(true);

            }
            catch (Exception)
            {
                // we just pass
                return Task.FromResult(false);
            }
        }
        #endregion

        #region Bindable methods
        public ICommand AddUserPicCommand => new Command(AddUserPicAsync);
        public async void AddUserPicAsync()
        {
            //string answer = await App.CurrentPage.DisplayActionSheet("بارگذاری تصویر پروفایل", "لغو", "بستن", "با گرفتن عکس", "از گالری تصاویر");
            string answer = await UserDialogs.Instance.ActionSheetAsync
                                                       (title: "بارگذاری تصویرِ پروفایل", 
                                                       cancel: "منصرف شدم",
                                                       destructive: null,
                                                       cancelToken: null,
                                                       buttons: new string[] { "با گرفتن عکس", "از گالری تصاویر" });
            switch (answer)
            {
                case "با گرفتن عکس":
                    if (!CrossMedia.Current.IsCameraAvailable)
                    {
                        await UserDialogs.Instance.AlertAsync("گوشیِ شما دوربین عکاسی ندارد", "خطا در فعال‌سازی دوربین", "متوجه شدم");
                        return;
                    }
                    else
                    {
                        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                        {
                            Name = "prPic.jpg"
                        });

                        if (file == null)
                            return;
                        UserImagePath = file.Path; // nice! (Neo)
                        //await App.CurrentPage.DisplayAlert("File Location Native", file.Path, "OK");
                        //await UserDialogs.Instance.AlertAsync(file.Path, "File Location ACR DIALOGS", "OK");


                        //image.Source = ImageSource.FromStream(() =>
                        //{
                        //    var stream = file.GetStream();
                        //    file.Dispose();
                        //    return stream;
                        //});
                    }
                    break;
                case "از گالری تصاویر":
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        await UserDialogs.Instance.AlertAsync("گوشیِ شما انتخابِ عکس از گالری را پشتیبانی نمی‌کند", "خطا در باز کردن گالری", "متوجه شدم");
                        return;
                    }
                    var existingFile = await CrossMedia.Current.PickPhotoAsync(/*new Plugin.Media.Abstractions.PickMediaOptions()*/);

                    if (existingFile == null)
                    {
                        await UserDialogs.Instance.AlertAsync("مشکلی در باز کردن فایل پیش آمد", "خطا", "متوجه شدم");
                        return;
                    }
                    UserImagePath = existingFile.Path;
                    break;
                default:
                    break;
            }
        }
        public ICommand SignUpCommand => new Command(SignUpAsync);

        private async void SignUpAsync()
        {
            // #test
            // do something else! sign the bastard up and let him through the gates of Valhalla
            //var res = await rstSrv.GetAsync<string>("https://127.0.0.1:8888/api/auth");
            //var resp= await rstSrv.GetAsync<TagResponseModel>("https://" + Consts.EMULATOR_IP + ":" + Consts.WEBSERVER_PORT + "/api/auth");
            //var res = await rstSrv.PostAsync("https://" + Consts.EMULATOR_IP + ":" + Consts.WEBSERVER_PORT + "/api/auth", Tag_QueryResponse.CreateQuery(TagDBTarget.AUTH, "salam"));
            //ConnectionRes = res;
            //await DependencyInjector.instance.Resolve<TagClient>().InitAsync();
            //await DependencyInjector.instance.Resolve<TagClient>().SendQueryToBackend("salam");
            await NavigationService.NavigateToAsync<MainPageVM>();
        }
        #endregion
    }
}
