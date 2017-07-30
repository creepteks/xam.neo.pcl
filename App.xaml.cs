using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Media;

namespace Tag.Core
{
    public enum TagPlatforms
    {
        android,
        ios,
        winPhone81,
        winPhone10,
        uwp
    }
    
    public partial class App : Application
    {
        
        private static Page _currentPage;

        public static Page CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        public App()
        {
            InitializeComponent();
        }

        private async Task SetUpDependencies()
        {
            await DependencyInjector.instance.Resolve<INavigationService>().InitializeAsync();
            await DependencyInjector.instance.Resolve<ILocationService>().InitializeAsync();
            bool XamMediaPlugin = await CrossMedia.Current.Initialize();
            if (!XamMediaPlugin)
            {
                throw new Exception("Something Wrong with Media Dependency plugin");
            }
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            await SetUpDependencies();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
