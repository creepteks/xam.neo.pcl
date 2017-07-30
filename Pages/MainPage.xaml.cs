using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tag.Core.Pages
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            //Detail = new HomePage() { Title = "HomeView" };
            //Master = new MainMenu() as Page;
            //Master.BindingContext = DependencyInjector.instance.Resolve(typeof(MainMenuVM)) as ViewModelBase;
            //NavigationPage.SetTitleIcon(this, this.Icon);
            //NavigationPage.SetHasNavigationBar(this, true);

            InitializeComponent();
        }
    }
}
