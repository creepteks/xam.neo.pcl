using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace neo.pcl.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        //private void AuthenticateViaTag_Clicked(object sender, EventArgs e)
        //{

        //}
        //private void AuthenticateViaGoogle_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}
